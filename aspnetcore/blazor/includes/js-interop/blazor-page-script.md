```javascript
const pageScriptInfoBySrc = new Map();

function registerPageScriptElement(src) {
  if (!src) {
    throw new Error('Must provide a non-empty value for the "src" attribute.');
  }

  let pageScriptInfo = pageScriptInfoBySrc.get(src);

  if (pageScriptInfo) {
    pageScriptInfo.referenceCount++;
  } else {
    pageScriptInfo = { referenceCount: 1, module: null };
    pageScriptInfoBySrc.set(src, pageScriptInfo);
    initializePageScriptModule(src, pageScriptInfo);
  }
}

function unregisterPageScriptElement(src) {
  if (!src) {
    return;
  }

  const pageScriptInfo = pageScriptInfoBySrc.get(src);
  
  if (!pageScriptInfo) {
    return;
  }

  pageScriptInfo.referenceCount--;
}

async function initializePageScriptModule(src, pageScriptInfo) {
  if (src.startsWith("./")) {
    src = new URL(src.substr(2), document.baseURI).toString();
  }

  const module = await import(src);

  if (pageScriptInfo.referenceCount <= 0) {
    return;
  }

  pageScriptInfo.module = module;
  module.onLoad?.();
  module.onUpdate?.();
}

function onEnhancedLoad() {
  for (const [src, { module, referenceCount }] of pageScriptInfoBySrc) {
    if (referenceCount <= 0) {
      module?.onDispose?.();
      pageScriptInfoBySrc.delete(src);
    }
  }

  for (const { module } of pageScriptInfoBySrc.values()) {
    module?.onUpdate?.();
  }
}

export function afterWebStarted(blazor) {
  customElements.define('page-script', class extends HTMLElement {
    static observedAttributes = ['src'];

    attributeChangedCallback(name, oldValue, newValue) {
      if (name !== 'src') {
        return;
      }

      this.src = newValue;
      unregisterPageScriptElement(oldValue);
      registerPageScriptElement(newValue);
    }

    disconnectedCallback() {
      unregisterPageScriptElement(this.src);
    }
  });

  blazor.addEventListener('enhancedload', onEnhancedLoad);
}
```
