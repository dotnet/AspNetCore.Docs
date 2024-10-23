/*! instant.page v1.1.0 - (C) 2019 Alexandre Dieulot - https://instant.page/license */

let urlToPreload
let mouseoverTimer
let lastTouchTimestamp

const prefetcher = document.createElement('link')
const isSupported = prefetcher.relList && prefetcher.relList.supports && prefetcher.relList.supports('prefetch')
const allowQueryString = 'instantAllowQueryString' in document.body.dataset

if (isSupported) {
    prefetcher.rel = 'prefetch'
    document.head.appendChild(prefetcher)

    const eventListenersOptions = {
        capture: true,
        passive: true,
    }
    document.addEventListener('touchstart', touchstartListener, eventListenersOptions)
    document.addEventListener('mouseover', mouseoverListener, eventListenersOptions)
}

function touchstartListener(event) {
    /* Chrome on Android calls mouseover before touchcancel so `lastTouchTimestamp`
     * must be assigned on touchstart to be measured on mouseover. */
    lastTouchTimestamp = performance.now()

    const linkElement = event.target.closest('a')

    if (!linkElement) {
        return
    }

    if (!isPreloadable(linkElement)) {
        return
    }

    linkElement.addEventListener('touchcancel', touchendAndTouchcancelListener, { passive: true })
    linkElement.addEventListener('touchend', touchendAndTouchcancelListener, { passive: true })

    urlToPreload = linkElement.href
    preload(linkElement.href)
}

function touchendAndTouchcancelListener() {
    urlToPreload = undefined
    stopPreloading()
}

function mouseoverListener(event) {
    if (performance.now() - lastTouchTimestamp < 1100) {
        return
    }

    const linkElement = event.target.closest('a')

    if (!linkElement) {
        return
    }

    if (!isPreloadable(linkElement)) {
        return
    }

    linkElement.addEventListener('mouseout', mouseoutListener, { passive: true })

    urlToPreload = linkElement.href

    mouseoverTimer = setTimeout(() => {
        preload(linkElement.href)
        mouseoverTimer = undefined
    }, 65)
}

function mouseoutListener(event) {
    if (event.relatedTarget && event.target.closest('a') == event.relatedTarget.closest('a')) {
        return
    }

    if (mouseoverTimer) {
        clearTimeout(mouseoverTimer)
        mouseoverTimer = undefined
    }
    else {
        urlToPreload = undefined
        stopPreloading()
    }
}

function isPreloadable(linkElement) {
    if (urlToPreload == linkElement.href) {
        return
    }

    const urlObject = new URL(linkElement.href)

    if (urlObject.origin != location.origin) {
        return
    }

    if (!allowQueryString && urlObject.search && !('instant' in linkElement.dataset)) {
        return
    }

    if (urlObject.hash && urlObject.pathname + urlObject.search == location.pathname + location.search) {
        return
    }

    if ('noInstant' in linkElement.dataset) {
        return
    }

    return true
}

function preload(url) {
    prefetcher.href = url
}

function stopPreloading() {
    /* The spec says an empty string should abort the prefetching
    * but Firefox 64 interprets it as a relative URL to prefetch. */
    prefetcher.removeAttribute('href')
}
