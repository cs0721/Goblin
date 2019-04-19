$(function () {
    $("#pic").click(function () {
        $("#pic").animate({
            height: '+=150px',
            width: '+=150px'
        });
        $("#pic").animate({
            height: '-=150px',
            width: '-=150px'
        });
    });

    $('.progress-button').progressInitialize();

    $("#submitButton").click(function (e) {
        e.preventDefault();
        $(this).progressTimed(2);
        setTimeout(function(){
            window.open("https://www.dramafever.com/drama/4914/1/Goblin%253A_The_Lonely_and_Great_God/?ap=1");
        },2000);
        
    });

    $("#submitButton1").click(function (e) {
        e.preventDefault();
        $(this).progressTimed(2);
        setTimeout(function () {
            window.open("https://www.viki.com/tv/31706c-goblin#modal-trailer");
        }, 2000);

    });

    $("#submitButton2").click(function (e) {
        e.preventDefault();
        $(this).progressTimed(2);
        setTimeout(function () {
            window.open("http://program.tving.com/tvn/dokebi/17/Board/List");
        }, 2000);

    });

    $("#submitButton3").click(function (e) {
        e.preventDefault();
        $(this).progressTimed(2);
        setTimeout(function () {
            window.open("http://program.tving.com/tvn/dokebi");
        }, 2000);

    });

    $(function() {
        $('#shake').click(function() {
            $(this).shake(2, 10, 400);
            setTimeout(function(){
                window.open("https://drive.google.com/drive/u/0/my-drive");
            },2000);
           
        });
    });
   
});

(function ($) {
    $.fn.shake = function(intShakes /*Amount of shakes*/, intDistance /*Shake distance*/, intDuration /*Time duration*/) {
        this.each(function() {
            var jqNode = $(this);
            jqNode.css({position: 'relative'});
            for (var x=1; x<=intShakes; x++) {
                jqNode.animate({ left: (intDistance * -1) },(((intDuration / intShakes) / 4)))
                .animate({ left: intDistance },((intDuration/intShakes)/2))
                .animate({ left: 0 },(((intDuration/intShakes)/4)));
            }
        });
        return this;
    }

    $.fn.progressInitialize = function () {



        return this.each(function () {

            var button = $(this),
				progress = 0;

      

            var options = $.extend({
                type: 'background-horizontal',
                loading: 'Loading..',
                finished: 'Done!'
            }, button.data());

      
            button.attr({ 'data-loading': options.loading, 'data-finished': options.finished });

            var bar = $('<span class="tz-bar ' + options.type + '">').appendTo(button);


            button.on('progress', function (e, val, absolute, finish) {

                if (!button.hasClass('in-progress')) {

  
                    bar.show();
                    progress = 0;
                    button.removeClass('finished').addClass('in-progress')
                }



                if (absolute) {
                    progress = val;
                }
                else {
                    progress += val;
                }

                if (progress >= 100) {
                    progress = 100;
                }

                if (finish) {

                    button.removeClass('in-progress').addClass('finished');

                    bar.delay(500).fadeOut(function () {

                        button.trigger('progress-finish');
                        setProgress(0);
                    });

                }

                setProgress(progress);
            });

            function setProgress(percentage) {
                bar.filter('.background-horizontal,.background-bar').width(percentage + '%');
                bar.filter('.background-vertical').height(percentage + '%');
            }

        });

    };


    $.fn.progressStart = function () {

        var button = this.first(),
			last_progress = new Date().getTime();

        if (button.hasClass('in-progress')) {

            return this;
        }

        button.on('progress', function () {
            last_progress = new Date().getTime();
        });

  

        var interval = window.setInterval(function () {

            if (new Date().getTime() > 2000 + last_progress) {

            

                button.progressIncrement(5);
            }

        }, 500);

        button.on('progress-finish', function () {
            window.clearInterval(interval);
        });

        return button.progressIncrement(10);
    };

    $.fn.progressFinish = function () {
        return this.first().progressSet(100);
    };

    $.fn.progressIncrement = function (val) {

        val = val || 10;

        var button = this.first();

        button.trigger('progress', [val])

        return this;
    };

    $.fn.progressSet = function (val) {
        val = val || 10;

        var finish = false;
        if (val >= 100) {
            finish = true;
        }

        return this.first().trigger('progress', [val, true, finish]);
    };

    

    $.fn.progressTimed = function (seconds, cb) {

        var button = this.first(),
			bar = button.find('.tz-bar');

        if (button.is('.in-progress')) {
            return this;
        }

     

        bar.css('transition', seconds + 's linear');
        button.progressSet(99);

        window.setTimeout(function () {
            bar.css('transition', '');
            button.progressFinish();

            if ($.isFunction(cb)) {
                cb();
            }

        }, seconds * 1000);
    };

})(jQuery);
