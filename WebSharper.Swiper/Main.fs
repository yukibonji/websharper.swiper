namespace WebSharper.Swiper.Extension

open WebSharper
open WebSharper.JavaScript
open WebSharper.InterfaceGenerator

module Definition =
    let SwiperClass = Class "Swiper"

    let Effect =
        Pattern.EnumStrings "effect"
            [
                "slide"
                "fade"
                "cube"
                "coverflow"
                "flip"
            ]

    let Cube = 
        Pattern.Config "cube" {
            Required =
                [
                    "slideShadows", T<bool>
                    "shadow", T<bool>
                    "shadowOffset", T<int>
                    "shadowScale", T<float>
                ]
            Optional = []
        }

    let Fade = 
        Pattern.Config "fade" {
            Optional = []
            Required = 
            [
                "crossFade", T<bool>
            ]
        }

    let Coverflow =
        Pattern.Config "coverflow" {
            Optional = []
            Required = 
            [
                "rotate", T<float>
                "stretch", T<float>
                "depth", T<float>
                "modifier", T<float>
                "slideShadows", T<bool>
            ]
        }

    let Flip = 
        Pattern.Config "flip" {
            Optional = []
            Required = 
            [
                "slideShadows", T<bool>
                "limitRotation", T<bool>
            ]
        }

    let Direction =
        Pattern.EnumStrings "direction"
            [
                "vertical"
                "horizontal"
            ]
    let ColumnFill =
        Pattern.EnumStrings "columnFill"
            [
                "row"
                "column"
            ]
    let TouchEventsTarget = 
        Pattern.EnumStrings "touchEventsTarget"
            [
                "container"
                "wrapper"
            ]

    let PaginationType =
        Pattern.EnumStrings "paginationType"
            [
                "bullets"
                "fraction"
                "progress"
                "custom"
            ]
    
    let Auto =
        Pattern.EnumStrings "auto"
            [
                "auto"
            ]

    let ControlBy =
        Pattern.EnumStrings "controlBy"
            [
                "slide"
                "container"
            ]

    let Callback = SwiperClass ^-> T<unit>

    let CallbackEvent = (SwiperClass * T<WebSharper.JavaScript.Dom.Event>) ^-> T<unit>

    let TouchEvent =
        Pattern.Config "touchEvent" {
            Required =
                [
                    "startX", T<int>
                    "startY", T<int>
                    "currentX", T<int>
                    "currentY", T<int>
                    "diff", T<int>
                ]
            Optional = []
        }

    let SlideType = T<Dom.Element>
                  + T<string>
                  + Type.ArrayOf T<Dom.Element>
                  + Type.ArrayOf T<string>

    let SwiperParameters = 
        Pattern.Config "SwipeParameters" {
            Required = []
            Optional =
                [
                    "initialSlide", T<int>
                    "direction", Direction.Type
                    "speed", T<int>
                    "setWrapperSize", T<bool>
                    "virtualTranslate", T<bool>
                    "width", T<int>
                    "height", T<int>
                    "autoHeight", T<bool>
                    "roundLengths", T<bool>
                    "nested", T<bool>
                    //Autoplay
                    "autoplay", T<int>
                    "autoplayStopOnLast", T<bool>
                    "autoplayDisableOnInteraction", T<bool>
                    //Progress
                    "watchSlidesProgress", T<bool>
                    "watchSlidesVisibility", T<bool>
                    //Freemode
                    "freeMode", T<bool>
                    "freeModeMomentum", T<bool>
                    "freeModeMomentumRatio", T<float>
                    "freeModeMomentumVelocityRatio", T<float>
                    "freeModeMomentumBounce", T<bool>
                    "freeModeMomentumBounceRatio", T<float>
                    "freeModeMinimumVelocity", T<float>
                    "freeModeSticky", T<bool>
                    //Effects
                    "effect", Effect.Type
                    "fade", Fade.Type
                    "cube", Cube.Type
                    "coverflow", Coverflow.Type 
                    "flip", Flip.Type
                    //Parallax
                    "parallax", T<bool>
                    //Slides grid
                    "spaceBetween", T<int>
                    "slidesPerView", T<int> + Auto.Type
                    "slidesPerColumn", T<int>
                    "slidesPerColumnFill", ColumnFill.Type
                    "slidesPerGroup", T<int>
                    "centeredSlides", T<bool>
                    "slidesOffsetBefore", T<int>
                    "slidesOffsetAfter", T<int>
                    //Grab Cursor
                    "grabCursor", T<bool>
                    //Touches
                    "touchEventsTarget", TouchEventsTarget.Type
                    "touchRatio", T<float>
                    "touchAngle", T<float>
                    "simulateTouch", T<bool>
                    "shortSwipes", T<bool>
                    "longSwipes", T<bool>
                    "longSwipesRatio", T<float>
                    "longSwipesMs", T<int>
                    "followFinger", T<bool>
                    "onlyExternal", T<bool>
                    "threshold", T<float>
                    "touchMoveStopPropagation", T<bool>
                    "iOSEdgeSwipeDetection", T<bool>
                    "iOSEdgeSwipeThreshold", T<int>
                    "touchReleaseOnEdges", T<bool>
                    "passiveListeners", T<bool>
                    //Touch Resistance
                    "resistance", T<bool>
                    "resistanceRatio", T<float>
                    //Clicks
                    "preventClicks", T<bool>
                    "preventClicksPropagation", T<bool>
                    "slideToClickedSlide", T<bool>
                    //Swiping / No swiping
                    "allowSwipeToPrev", T<bool>
                    "allowSwipeToNext", T<bool>
                    "noSwiping", T<bool>
                    "noSwipingClass", T<string>
                    "swipeHandler", T<string> + T<JavaScript.Dom.Element>
                    //Navigation Controls
                    "uniqueNavElements", T<bool>
                    //Pagination
                    "pagination", T<string> + T<JavaScript.Dom.Element>
                    "paginationType", PaginationType.Type
                    "paginationHide", T<bool>
                    "paginationClickable", T<bool>
                    "paginationElement", T<string>
                    "paginationBulletRender", SwiperClass * T<int> * T<string> ^-> T<string> 
                    "paginationFractionRender", SwiperClass * T<string> * T<string> ^-> T<string>
                    "paginationProgressRender", SwiperClass * T<string> ^-> T<string>
                    "paginationCustomRender", SwiperClass * T<int> * T<int> ^-> T<string>
                    //Navigation Buttons
                    "nextButton", T<string> + T<JavaScript.Dom.Element>
                    "prevButton", T<string> + T<JavaScript.Dom.Element>
                    //Scrollbar
                    "scrollbar", T<string> + T<JavaScript.Dom.Element>
                    "scrollbarHide", T<bool>
                    "scrollbarDraggable", T<bool>
                    "scrollbarSnapOnRelease", T<bool>
                    //Accessibility
                    "a11y", T<bool>
                    "prevSlideMessage", T<string>
                    "nextSlideMessage", T<string>
                    "firstSlideMessage", T<string>
                    "lastSlideMessage", T<string>
                    "paginationBulletMessage", T<string>
                    //Keyboard / Mousewheel
                    "keyboardControl", T<bool>
                    "mousewheelControl", T<bool>
                    "mousewheelForceToAxis", T<bool>
                    "mousewheelReleaseOnEdges", T<bool>
                    "mousewheelInvert", T<bool>
                    "mousewheelSensitivity", T<float>
                    "mousewheelEventsTarged", T<string> + T<JavaScript.Dom.Element>
                    //Hash/History Navigation
                    "hashnav", T<bool>
                    "hashnavWatchState", T<bool>
                    "history", T<string>
                    "replaceState", T<bool>
                    //Images
                    "preloadImages", T<bool>
                    "updateOnImagesReady", T<bool>
                    "lazyLoading", T<bool>
                    "lazyLoadingInPrevNext", T<bool>
                    "lazyLoadingInPrevNextAmount", T<int>
                    "lazyLoadingOnTransitionStart",  T<bool>
                    //Loop
                    "loop", T<bool> 
                    "loopAdditionalSlides", T<int>
                    "loopSlides", T<WebSharper.JavaScript.Number> 
                    //Zoom
                    "zoom", T<bool>
                    "zoomMax", T<float>
                    "zoomMin", T<float>
                    "zoomToggle", T<bool>
                    //Controller
                    "control", SwiperClass.Type + Type.ArrayOf SwiperClass.Type
                    "controlInverse", T<bool>
                    "controlBy", ControlBy.Type
                    //Observer
                    "observer", T<bool>
                    "observeParents", T<bool>
                    //Breakpoints
                    "breakpoints", T<obj> //K�RD�S
                    //Callbacks
                    "runCallbacksOnInit", T<bool>
                    "onInit", Callback
                    "onSlideChangeStart", Callback
                    "onSlideChangeEnd", Callback
                    "onSlideNextStart", Callback
                    "onSlideNextEnd", Callback
                    "onSlidePrevStart", Callback
                    "onSlidePrevEnd", Callback
                    "onTransitionStart", Callback
                    "onTransitionEnd", Callback
                    "onTouchStart", CallbackEvent
                    "onTouchMove", CallbackEvent
                    "onTouchMoveOpposite", CallbackEvent
                    "onSliderMove", CallbackEvent
                    "onTouchEnd", CallbackEvent
                    "onClick", CallbackEvent
                    "onTap", CallbackEvent
                    "onDoubleTap", CallbackEvent
                    "onImagesReady", Callback 
                    "onProgress", SwiperClass * T<float> ^-> T<unit> 
                    "onReachBeginning", Callback
                    "onReachEnd", Callback
                    "onDestroy", Callback
                    "onSetTranslate", SwiperClass * T<float> ^-> T<unit>
                    "onSetTransition", SwiperClass * T<float> ^-> T<unit> 
                    "onAutoplay", Callback
                    "onAutoplayStart", Callback
                    "onAutoplayStop", Callback
                    "onLazyImageLoad", SwiperClass * T<Dom.Element> * T<Dom.Element> ^-> T<unit> //TODO: test if these types work with javascript
                    "onLazyImageReady", SwiperClass * T<Dom.Element> * T<Dom.Element> ^-> T<unit>
                    "onPaginationRendered", SwiperClass * T<Dom.Element> ^-> T<unit>
                    "onScroll", SwiperClass * T<Dom.Element> ^-> T<unit>
                    "onBeforeResize", Callback
                    "onAfterResize", Callback
                    "onKeyPress", SwiperClass * T<int> ^-> T<unit>
                    //Namespace
                    "containerModifierClass", T<string>
                    "slideClass", T<string>
                    "slideActiveClass", T<string>
                    "slideDuplicatedActiveClass", T<string>
                    "slideVisibleClass", T<string>
                    "slideDuplicateClass", T<string>
                    "slideNextClass", T<string>
                    "slideDuplicatedNextClass", T<string>
                    "slidePrevClass", T<string>
                    "slideDuplicatedPrevClass", T<string>
                    "wrapperClass", T<string>
                    "bulletClass", T<string>
                    "bulletActiveClass", T<string>
                    "paginationHiddenClass", T<string>
                    "paginationCurrentClass", T<string>
                    "paginationTotalClass", T<string>
                    "paginationProgressbarClass", T<string>
                    "paginationClickableClass", T<string>
                    "paginationModifierClass", T<string>
                    "buttonDisabledClass", T<string>
                    "lazyLoadingClass", T<string>
                    "lazyStatusLoadingClass", T<string>
                    "lazyStatusLoadedClass", T<string>
                    "lazyPreloaderClass", T<string>
                    "preloaderClass", T<string>
                    "zoomContainerClass", T<string>
                    "notificationClass", T<string>
                ]
        }

    let Swiper =
        SwiperClass
        |+> Static [
            Constructor ((T<string> + T<Dom.Element>) * !? SwiperParameters.Type)
        ]
        |+> Instance [
            "params" =? SwiperParameters.Type
            "container" =? T<JQuery.JQuery>
            "wrapper" =? T<JQuery.JQuery>
            "slides" =? Type.ArrayOf T<JQuery.JQuery>
            "nextButton" =? T<JQuery.JQuery>
            "prevButton" =? T<JQuery.JQuery>
            "bullets" =? Type.ArrayOf T<JQuery.JQuery>
            "width" =? T<int>
            "height" =? T<int>
            "translate" =? T<int>
            "progress" =? T<float>
            "activeIndex" =? T<int>
            "realIndex" =? T<int>
            "previousIndex" =? T<int>
            "isBeginning" =? T<bool>
            "isEnd" =? T<bool>
            "autoplaying" =? T<bool>
            "animating" =? T<bool>
            "touches" =? TouchEvent.Type
            "clickedIndex" =? T<int>
            "clickedSlide" =? T<Dom.Element>
            
            "slideNext" => !? T<bool>?runCallbacks * !? T<int>?speed ^-> T<unit>
            "slidePrev" => !? T<bool>?runCallbacks * !? T<int>?speed ^-> T<unit>
            "slideTo" => T<int>?index * !? T<int>?speed * !?T<bool>?runCallbacks ^-> T<unit>
            
            "update" => !? T<bool>?updateTranslate ^-> T<unit>
            
            "onResize" => T<unit> ^-> T<unit>
            "detachEvents" => T<unit> ^-> T<unit>
            "attachEvents" => T<unit> ^-> T<unit>
            "startAutoplay" => T<unit> ^-> T<unit>
            "stopAutoplay" => T<unit> ^-> T<unit>
            
            "destroy" => !? T<bool>?deleteInstance * !? T<bool>?cleanupStyles ^-> T<unit>
            
            "appendSlide" => SlideType ^-> T<unit>
            "prependSlide" => SlideType ^-> T<unit>
            "removeSlide" => SlideType ^-> T<unit>
            "removeAllSlides" => T<unit> ^-> T<unit>

            "setWrapperTranslate" => T<float> ^-> T<unit>
            "getWrapperTranslate" => T<unit> ^-> T<float>

            "on" => T<string>?callback * T<JavaScript.Function>?handler ^-> TSelf
            "once" => T<string>?callback * T<JavaScript.Function>?handler ^-> TSelf
            "off" => T<string>?callback ^-> TSelf

            "lockSwipeToNext" => T<unit> ^-> T<unit>
            "unlockSwipeToNext" => T<unit> ^-> T<unit>
            "lockSwipeToPrev" => T<unit> ^-> T<unit>
            "unlockSwipeToPrev" => T<unit> ^-> T<unit>
            "lockSwipes" => T<unit> ^-> T<unit>
            "unlockSwipes" => T<unit> ^-> T<unit>
            "disableMousewheelControl" => T<unit> ^-> T<unit>
            "enableMousewheelControl" => T<unit> ^-> T<unit>
            "disableKeyboardControl" => T<unit> ^-> T<unit>
            "enableKeyboardControl" => T<unit> ^-> T<unit>
            "disableTouchControl" => T<unit> ^-> T<unit>
            "enableTouchControl" => T<unit> ^-> T<unit>
            "unsetGrabCursor" => T<unit> ^-> T<unit>
            "setGrabCursor" => T<unit> ^-> T<unit>
        ]



    let Assembly =
        Assembly [
            Namespace "WebSharper.Swiper.Resources" [
                Resource "Css" "https://cdnjs.cloudflare.com/ajax/libs/Swiper/3.4.2/css/swiper.css" |> AssemblyWide
                Resource "Js" "https://cdnjs.cloudflare.com/ajax/libs/Swiper/3.4.2/js/swiper.js" |> AssemblyWide
            ]
            Namespace "WebSharper.Swiper" [
                Effect
                Cube
                Fade
                Coverflow
                Flip
                Direction
                ColumnFill
                TouchEventsTarget
                PaginationType
                Auto
                ControlBy
                TouchEvent
                SwiperParameters
                Swiper
            ]
        ]


[<Sealed>]
type Extension() =
    interface IExtension with
        member x.Assembly = Definition.Assembly

[<assembly: Extension(typeof<Extension>)>]
do ()
