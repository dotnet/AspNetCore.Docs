  // Test css properties
  function testProps( props, prefixed ) {
      var _style = document.createElement('div').style;
      for ( var i in props ) {
          if ( _style[ props[i] ] !== undefined ) {
              return prefixed == 'pfx' ? props[i] : true;
          }
      }
      return false;
  }


  // CSS TRANSITION SUPPORT (Shoutout: http://www.modernizr.com/)
  // ============================================================

  function transitionEnd() {
    var el = document.createElement('bootstrap')

    var transEndEventNames = {
      'WebkitTransition' : 'webkitTransitionEnd'
    , 'MozTransition'    : 'transitionend'
    , 'OTransition'      : 'oTransitionEnd otransitionend'
    , 'transition'       : 'transitionend'
    }

    for (var name in transEndEventNames) {
      if (el.style[name] !== undefined) {
        return { end: transEndEventNames[name] }
      }
    }
  }
  // http://blog.alexmaccaw.com/css-transitions
  $.fn.emulateTransitionEnd = function (duration) {
    var called = false, $el = this
    $(this).one($.support.transition.end, function () { called = true })
    var callback = function () { if (!called) $($el).trigger($.support.transition.end) }
    setTimeout(callback, duration)
    return this
  }


  function csstransforms() {
    var prefixes = ['transformProperty', 'WebkitTransform', 'MozTransform', 'msTransform'];
    return !!testProps( prefixes );
  }

  // @todo: test more than only webkit ;-)
  function csstransforms3d() {
    return ('WebKitCSSMatrix' in window && 'm11' in new WebKitCSSMatrix());
  }

  $(function () {
    $.support.transition = transitionEnd()
    $.support.csstransforms = csstransforms()
    $.support.csstransforms3d = csstransforms3d()
  })
