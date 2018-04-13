
/**
* 这是轮播
* @param   $tabLi  '拿来轮播的li标签'
* @param $liname  "li标签名字"
* @param $picUl    '执行动画的容器'
* @param imgWidth   '移动的长度'
* @param time       '动画时间'
* @param $showTime1  'li动画执行的时间'
* @param $showTime2  '自动轮播的时间'
* @param $bannar     '轮播的容器,不隐藏按钮则设为no'
* @param $btn        '点击的按钮'
* @param $btnDiv      '按钮里的div'
* @param $hover       '按钮样式的名字'
* @param $yesno       '是否开启自动轮播'
* @param $hidde       '是否隐藏按钮'
*/

function carousel($tabLi, $liname, $picUl, imgWidth, time, $showTime1, $showTime2, $bannar, $btn, $btnDiv, $hover, $yesno, $hidde) {
    var index = 0;
    var nowTime = new Date();
    $tabLi.hover(function () {
        index = $(this).index();
        $(this).addClass($liname).siblings().removeClass($liname);
        $picUl.animate({
            marginLeft: -imgWidth * (index + 1) + 'px'
        }, $showTime1);
    });
    if ($bannar != 'no') {
        $bannar.hover(function () {
                $btn.show();
            clearInterval(timer);
        }, function () {
            if ($hidde == 'true') {
                $btn.hide();
            }
            timer = setInterval(function () {
                index++;
                fn($tabLi, $liname, $picUl, imgWidth, time);
            }, $showTime2);
        });
        $tabLi.hover(function () {
            clearInterval(timer);
        }, function () {
            timer = setInterval(function () {
                index++;
                fn($tabLi, $liname, $picUl, imgWidth, time);
            }, $showTime2);

        })
    }
    $btnDiv.hover(function () {
        if ($btn.show()==false) {
            
        }
        else {
            $(this).addClass($hover);
        }
    }, function () {
        $(this).removeClass($hover);
    }).click(function () {
        if (new Date - nowTime > time) {
            nowTime = new Date();
            var i = $(this).index();
            i ? index++ : index--;
            fn($tabLi, $liname, $picUl, imgWidth, time);
        }
    }).mousedown(function () {
        return false;
    });
    if ($yesno == 'yes') {
        var timer = setInterval(function () {
            index++;
            fn($tabLi, $liname, $picUl, imgWidth, time);
        }, $showTime2);
    }
    function fn($tabLi, $liname, $picUl, $imgWidth, time) {
        var liIndex = index;
        if (liIndex >= $tabLi.length) {
            liIndex = 0;
        }
        else if (liIndex < 0) {
            liIndex = $tabLi.length - 1;
        }
        $tabLi.eq(liIndex).addClass($liname).siblings().removeClass($liname);
        $picUl.animate({
            marginLeft: -$imgWidth * (index + 1) + 'px'
        }, time, function () {
            if (index == $tabLi.length) {
                $picUl.css('marginLeft', -$imgWidth + 'px');
                index = 0;
            }
            else if (index < 0) {
                $picUl.css('marginLeft', -$imgWidth * ($tabLi.length) + 'px');
                index = $tabLi.length - 1;
            }
        });
    }
};