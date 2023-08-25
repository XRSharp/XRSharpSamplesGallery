
document.createInputManager3D = function (callback) {
    if (document.inputManager3D) return;

    // This must remain synchronized with the EVENTS enum defined in InputManager3D.cs.
    // Make sure to change both files if you update this !
    const EVENTS = {
        //MOUSE_MOVE: 0,
        MOUSE_LEFT_DOWN: 1,
        MOUSE_LEFT_UP: 2,
        MOUSE_RIGHT_DOWN: 3,
        MOUSE_RIGHT_UP: 4,
        MOUSE_ENTER: 5,
        MOUSE_LEAVE: 6,
        //WHEEL: 7,
        //KEYDOWN: 8,
        //KEYUP: 9,
        //FOCUS: 10,
        //BLUR: 11,
        //KEYPRESS: 12,
        //INPUT: 13,
        TOUCH_START: 14,
        TOUCH_END: 15,
        //TOUCH_MOVE: 16,
        //WINDOW_BLUR: 17,

        MOUSE_DOWN: 20,
        MOUSE_UP: 21,
        CLICK: 22,
        FUSING: 23,
    };

    //const MODIFIERKEYS = {
    //    NONE: 0,
    //    CONTROL: 1,
    //    ALT: 2,
    //    SHIFT: 4,
    //    WINDOWS: 8,
    //};

    //let _modifiers = MODIFIERKEYS.NONE;
    let _mouseCapture = null;

    //function setModifiers(e) {
    //    _modifiers = MODIFIERKEYS.NONE;
    //    if (e.ctrlKey)
    //        _modifiers |= MODIFIERKEYS.CONTROL;
    //    if (e.altKey)
    //        _modifiers |= MODIFIERKEYS.ALT;
    //    if (e.shiftKey)
    //        _modifiers |= MODIFIERKEYS.SHIFT;
    //    if (e.metaKey)
    //        _modifiers |= MODIFIERKEYS.WINDOWS;
    //};

    function getClosestElementId(element) {
        while (element) {
            const xamlid = element.xamlid;
            if (xamlid) {
                return xamlid;
            }

            element = element.parentElement;
        }

        return '';
    };

    document.inputManager3D = {
        addListeners: function (element, isFocusable) {
            const view = typeof element === 'string' ? document.getElementById(element) : element;
            if (!view) return;

            // raycaster component observes objects with 'interactive' attribute
            view.setAttribute('interactive', '');
            view.setAttribute('pressable', '');

            view.addEventListener('mousedown', function (e) {
                if (!e.isHandled) {
                    e.isHandled = true;
                    let id = (_mouseCapture === null || this === _mouseCapture) ? getClosestElementId(this) : '';
                    let mouseEvent = e.detail.mouseEvent;
                    let touchEvent = e.detail.touchEvent;
                    if (mouseEvent) {
                        switch (mouseEvent.button) {
                            case 0:
                                callback(id, EVENTS.MOUSE_LEFT_DOWN, e);
                                break;
                            case 2:
                                callback(id, EVENTS.MOUSE_RIGHT_DOWN, e);
                                break;
                        }
                    }
                    if (touchEvent) {
                        callback(id, EVENTS.TOUCH_START, e);
                    }
                    callback(id, EVENTS.MOUSE_DOWN, e);
                }
            });

            view.addEventListener('mouseup', function (e) {
                if (!e.isHandled) {
                    e.isHandled = true;
                    const target = _mouseCapture || this;
                    let id = getClosestElementId(target);
                    let mouseEvent = e.detail.mouseEvent;
                    let touchEvent = e.detail.touchEvent;
                    if (mouseEvent) {
                        switch (mouseEvent.button) {
                            case 0:
                                callback(id, EVENTS.MOUSE_LEFT_UP, e);
                                break;
                            case 2:
                                callback(id, EVENTS.MOUSE_RIGHT_UP, e);
                                break;
                        }
                    }
                    if (touchEvent) {
                        callback(id, EVENTS.TOUCH_END, e);
                    }
                    callback(id, EVENTS.MOUSE_UP, e);
                }
            });

            view.addEventListener('click', function (e) {
                if (!e.isHandled) {
                    e.isHandled = true;
                    const target = _mouseCapture || this;
                    callback(getClosestElementId(target), EVENTS.MOUSE_UP, e);
                }
            });

            //view.addEventListener('mousemove', function (e) {
            //    if (!e.isHandled) {
            //        e.isHandled = true;
            //        const target = _mouseCapture || this;
            //        callback(getClosestElementId(target), EVENTS.MOUSE_MOVE, e);
            //    }
            //});

            //view.addEventListener('wheel', function (e) {
            //    if (!e.isHandled) {
            //        e.isHandled = true;
            //        callback(getClosestElementId(this), EVENTS.WHEEL, e);
            //    }
            //});

            view.addEventListener('mouseenter', function (e) {
                if (_mouseCapture === null || this === _mouseCapture) {
                    callback(getClosestElementId(this), EVENTS.MOUSE_ENTER, e);
                }
            });

            view.addEventListener('mouseleave', function (e) {
                if (_mouseCapture === null || this === _mouseCapture) {
                    callback(getClosestElementId(this), EVENTS.MOUSE_LEAVE, e);
                }
            });

            //if (isTouchDevice()) {
            //    view.addEventListener('touchstart', function (e) {
            //        if (!e.isHandled) {
            //            e.isHandled = true;
            //            callback(getClosestElementId(this), EVENTS.TOUCH_START, e);
            //        }
            //    }, { passive: true });

            //    view.addEventListener('touchend', function (e) {
            //        if (!e.isHandled) {
            //            e.isHandled = true;
            //            callback(getClosestElementId(this), EVENTS.TOUCH_END, e);
            //            e.preventDefault();
            //        }
            //    });

            //    view.addEventListener('touchmove', function (e) {
            //        if (!e.isHandled) {
            //            e.isHandled = true;
            //            callback(getClosestElementId(this), EVENTS.TOUCH_MOVE, e);
            //        }
            //    }, { passive: true });
            //}

            //if (isFocusable) {
            //    view.addEventListener('keypress', function (e) {
            //        if (!e.isHandled) {
            //            e.isHandled = true;
            //            callback(getClosestElementId(this), EVENTS.KEYPRESS, e);
            //        }
            //    });

            //    view.addEventListener('input', function (e) {
            //        if (!e.isHandled) {
            //            e.isHandled = true;
            //            callback(getClosestElementId(this), EVENTS.INPUT, e);
            //        }
            //    });

            //    view.addEventListener('keydown', function (e) {
            //        if (!e.isHandled) {
            //            e.isHandled = true;
            //            setModifiers(e);
            //            callback(getClosestElementId(this), EVENTS.KEYDOWN, e);
            //        }
            //    });

            //    view.addEventListener('keyup', function (e) {
            //        if (!e.isHandled) {
            //            e.isHandled = true;
            //            setModifiers(e);
            //            callback(getClosestElementId(this), EVENTS.KEYUP, e);
            //        }
            //    });
            //}
        },
        //getModifiers: function () {
        //    return _modifiers;
        //},
        captureMouse: function (element) {
            _mouseCapture = element;
        },
        releaseMouseCapture: function () {
            _mouseCapture = null;
        },
    };
};
