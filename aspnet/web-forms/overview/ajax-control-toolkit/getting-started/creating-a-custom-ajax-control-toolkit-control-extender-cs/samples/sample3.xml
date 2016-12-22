Type.registerNamespace('CustomExtenders');

CustomExtenders.DisabledButtonBehavior = function(element) {

    CustomExtenders.DisabledButtonBehavior.initializeBase(this, [element]);

    this._targetButtonIDValue = null;
    this._disabledTextValue = null;

}

CustomExtenders.DisabledButtonBehavior.prototype = {

    initialize : function() {
        CustomExtenders.DisabledButtonBehavior.callBaseMethod(this, 'initialize');

        // Initalization code
        $addHandler(this.get_element(), 'keyup', 
        Function.createDelegate(this, this._onkeyup));
        this._onkeyup();
    },

    dispose : function() {
        // Cleanup code 

        CustomExtenders.DisabledButtonBehavior.callBaseMethod(this, 'dispose');
    },

    // Property accessors 
    //
    get_TargetButtonID : function() {
        return this._targetButtonIDValue;
    },

    set_TargetButtonID : function(value) {
        this._targetButtonIDValue = value;
    },

    get_DisabledText : function() {
        return this._disabledTextValue;
    },

    set_DisabledText : function(value) {
        this._disabledTextValue = value;
    },

  _onkeyup : function() {
  
    var e = $get(this._targetButtonIDValue);
    if (e) {
      var disabled = ("" == this.get_element().value);
      e.disabled = disabled;
      if ( this._disabledTextValue) {
        if (disabled) {
          this._oldValue = e.value;
          e.value = this._disabledTextValue;
        }
        else
        {
          if(this._oldValue){
            e.value = this._oldValue;
          }
        }
      }
    }
  }

}

CustomExtenders.DisabledButtonBehavior.registerClass('CustomExtenders.DisabledButtonBehavior', AjaxControlToolkit.BehaviorBase);