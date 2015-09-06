(function ($) {
    var touches = {};
    var touchEvents={};
    $.tapDelay=220;
    $.holdDelay = 700;
    //滑动阀值
    $.swipeLen = 30;
    function getEle(e){
        touches.el=$(("tagName" in e.target)? e.target: e.target.parentNode);
       return touches.el;
    }

$(function(){
    //touchstart(轻击)事件
            $(document).on("touchstart", function (e) {
                //parseEvent(callback,e);
               var data = _eventVal(e)
                touches.tapTime = setTimeout(function () {
                    getEle(e).trigger("tap",data);
                    clearTimeout(touches.tapTime);
                }, $.tapDelay)

            }).on("touchend",function(e){
                getEle(e).trigger("tapend");
            }).on("touchstart",function(e){//hold事件

                var data = _eventVal(e)
                var t=setTimeout(function(){
                    clearTimeout(t);
                    clearTimeout(touches.tapTime)
                }, $.tapDelay-5);
                touches.holdTime=setTimeout(function(){
                    getEle(e).trigger("hold",data);
                    clearTimeout(touches.holdTime);
                }, $.holdDelay);
                getEle(e)[0].addEventListener("touchend",end,false);
                function end(){
                    clearTimeout(t);
                    clearTimeout(touches.holdTime);
                    getEle(e)[0].removeEventListener("touchend",end,false)
                }
            }).on("touchstart",function(e){//swip
                var x, y, x1, y1;
                x = e.touches[0].clientX;
                y = e.touches[0].clientY;
                touchEvents.swip=function(e){
                    if(x==x1&&y==y1){
                        return;
                    }
                    _stop();
                    x1 = e.touches[0].clientX;
                    y1 = e.touches[0].clientY;
                    var obj = {x: x, y: y, x1: x1, y1: y1, lenx: Math.abs(x - x1), leny: Math.abs(y - y1)};
                    var data = _eventVal(e, obj);
                    if (Math.abs(x - x1) > $.swipeLen || Math.abs(y - y1) > $.swipeLen) {

                        getEle(e).trigger("swip" ,data);

                        if (Math.abs(x - x1) > Math.abs(y - y1)) {
                            if (x > x1) {

                                 getEle(e).trigger("swipleft",data);

                            }
                        }else if (Math.abs(x - x1) > Math.abs(y - y1)) {
                            if (x < x1) {
                                getEle(e).trigger("swipright",data);

                            }
                        }else  if (Math.abs(x - x1) < Math.abs(y - y1)) {
                            if (y > y1) {
                                getEle(e).trigger("swipup",data);

                            }
                        }else    if (Math.abs(x - x1) < Math.abs(y - y1)) {
                            if (y < y1) {
                                getEle(e).trigger("swipdown",data);

                            }
                        }
                        x=x1;y=y1;
                    }


                }
                var target=getEle(e);
                $(document).on("touchmove",touchEvents.swip);
                $(document).on("touchend",end);
                function end(){
                    $(this).off("touchmove",touchEvents.move) ;
                    $(this).off("touchend",end);
                }

            }).on("touchstart",function(e){//拖拽事件
                var x, y, startx, starty, initx, inity, x1, y1, data, currentx, currenty;
                x = e.touches[0].clientX;
                y = e.touches[0].clientY;
                startx = e.touches[0].clientX;
                starty = e.touches[0].clientY;
                initx = e.touches[0].clientX;
                inity = e.touches[0].clientY;
                touchEvents.drag=function(e){
                    _stop();
                    x1 = e.touches[0].clientX;
                    y1 = e.touches[0].clientY;
                    currentx = x1 - x;
                    currenty = y1 - y;
                    if (x1 < startx) {

                        if (x1 > x) {
                            startx = x;
                        }
                    }
                    if (x1 > startx) {

                        if (x1 < x) {
                            startx = x;
                        }
                    }

                    if (y1 < starty) {

                        if (y1 > y) {
                            starty = y;
                        }
                    }
                    if (y1 > starty) {

                        if (y1 < y) {
                            starty = y;
                        }
                    }

                    var obj = {
                        x: x,
                        y: y,
                        x1: x1,
                        y1: y1,
                        lenx: Math.abs(x1 - initx),
                        leny: Math.abs(y1 - inity),
                        currentx: currentx,
                        currenty: currenty
                    }
                    data = _eventVal(e, obj);
                    getEle(e).trigger("drag",data);
                        if (Math.abs(x - x1) > Math.abs(y - y1)) {
                            getEle(e).trigger("dragx",data);
                            if (x1 < x) {
                                data.dir = "l"
                                getEle(e).trigger("dragleft",data);
                            } else {
                                data.dir = "r";
                                getEle(e).trigger("dragright",data);
                            }

                        }else if (Math.abs(x - x1) < Math.abs(y - y1)) {
                            getEle(e).trigger("dragy",data);
                            if (y1 < y) {
                                data.dir = "t"
                                getEle(e).trigger("dragup",data);
                            } else {
                                data.dir = "b";
                                getEle(e).trigger("dragdown",data);
                            }

                        }


                    x = x1;
                    y = y1;
                }
                var target=getEle(e);
                $(document).on("touchmove", touchEvents.drag);
                $(document).on("touchend", end);
                function end(){
                    $(this).off("touchmove", touchEvents.drag);
                    $(this).off("touchend", end);
                }
            }).on("touchstart",function(e){//旋转事件
                var startx;
                var starty;
                var centerx;
                var centery;
                var angle = 0;
                var target=getEle(e);
                centerx = target.offset().left + (target[0].offsetWidth / 2);
                centery = target.offset().top + (target[0].offsetHeight / 2);
                startx = e.touches[0].pageX;
                starty = e.touches[0].pageY;
                touchEvents.rotate=function(e){
                   // e.preventDefault();
                    _stop()
                    var speed = 5;
                    var x = e.touches[0].pageX;
                    var y = e.touches[0].pageY;
                    var newx = x - startx;
                    var newy = y - starty;
                    var aa = Math.atan2(centery - y, centerx - x) * 180 / Math.PI;
                    e.angle = aa;
                    target.trigger("rotate",e);
                    startx = x;
                    starty = y


                }
                    var target=getEle(e);
                $(document).on("touchmove", touchEvents.rotate);
                $(document).on("touchend", end);
                function end(){
                    $(this).off("touchmove", touchEvents.rotate);
                    $(this).off("touchend", end);
                }
            }).on("touchstart",function(e){
                var x,x1;
                var data={};
                var x= $(window).scrollTop();
                $(window).on("scroll",function(e){             $(document).trigger("pagescroll")
                    var x1=$(window).scrollTop();
                 if(x<x1){
                     data.len=x1-x;
                     $(document).trigger("pagedown",data)

                 }else if(x>x1){
                     data.len=x-x1;
                     $(document).trigger("pageup",data)
                 }

                })
                $(document).on("touchmove",function(){
                    var x1=$(window).scrollTop();
                    if(x1==0){
                        data.len=x1-x;
                        $(document).trigger("pagetop",data)

                    }else if(x==x1&&x1!=0){
                        data.len=x-x1;
                        $(document).trigger("pagebottom",data)
                    }

                })

            })





})






    //停止事件
    function _stop() {
        for(var i in touches){
            clearTimeout(touches[i]);
        }
    }


    //滚动取消所有事件
    $(window).on("scroll", function (e) {
        _stop();
        for(var i in touchEvents){
            $(document).off("touchmove",touchEvents.i)
        }
    })

    //处理事件对象返回值
    function _eventVal(e, obj) {
        var data = e;
        data.clientX = e.touches[0].clientX;
        data.screenX = e.touches[0].screenX;
        data.pageX = e.touches[0].pageX;
        data.target= e.touches[0].target;
        if (obj) {
            data.x = obj.x;
            data.y = obj.y;
            data.x1 = obj.x1;
            data.y1 = obj.y1;
            data.lenx = obj.lenx;
            data.leny = obj.leny;
            data.currentx = obj.currentx;
            data.currenty = obj.currenty;
        }
        return data;
    }
    function parseEvent(callback,e){
        var p=(/function\s+\((\w*),?[\w,]?\)/.exec(callback))[1];
        if(!p){
            return;
        }
        var stop=(eval("/"+p+".stopPropagation\\s*\\(\\s*\\)/").exec(callback));
        if(stop){
            e.stopPropagation()
        }
        var de=(eval("/"+p+".preventDefault\\s*\\(\\s*\\)/").exec(callback))
        {
            e.preventDefault();
        }
    };

    ("tap hold swip swipleft swipright swipup swipdown drag dragx dragy dragleft dragright dragdown dragup").split(" ").forEach(function(event){
        $.fn[event] = function (callback) {
            return (0 in arguments) ?
                this.on(event, callback) :
                this.trigger(event);
        }
    });
    ("pagedown pageup pagetop pagebottom pagescroll").split(" ").forEach(function(event){
        $.fn[event] = function (callback) {
            return (0 in arguments) ?
                $(document).on(event, callback) :
                $(document).trigger(event);
        }
    })

})(Zepto);