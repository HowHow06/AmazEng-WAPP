
(function ($) {
    "use strict";

    //  Main Menu Offcanvas
    $('.primary-menu').find('li a').each(function () {
        if ($(this).next().length > 0) {
            $(this).parent('li').append('<span class="menu-trigger"><i class="fal fa-angle-down"></i></span>');
        }
    });



    // expands the dropdown menu on each click
    $('.primary-menu').find('li .menu-trigger').on('click', function (e) {
        e.preventDefault();
        $(this).toggleClass('open').parent('li').children('ul').stop(true, true).slideToggle(350);
        $(this).find("i").toggleClass("fa-angle-up fa-angle-down");
    });



    // check browser width in real-time
    function breakpointCheck() {
        var windoWidth = window.innerWidth;

        if (windoWidth <= 991) {
            $('.header-navbar').addClass('mobile-menu');
        } else {
            $('.header-navbar').removeClass('mobile-menu');
        }
    }

    breakpointCheck();
    $(window).on('resize', function () {
        breakpointCheck();
    });


    $('.nav-toggler').on('click', function (e) {
        $('.site-navbar').toggleClass('menu-on');
        e.preventDefault();
    });

    // Close menu on toggler click
    $('.nav-close').on('click', function (e) {
        $('.site-navbar').removeClass('menu-on');
        e.preventDefault();
    });


    // Offcanvas Info menu

    $('.offcanvas-icon').on('click', function (e) {
        $('.offcanvas-info').toggleClass('offcanvas-on');
        e.preventDefault();
    });

    // Close menu on toggler click
    $('.info-close').on('click', function (e) {
        $('.offcanvas-info').removeClass('offcanvas-on');
        e.preventDefault();
    });

    //Search Box addClass removeClass
    $('.header_search_btn > a').on('click', function () {
        $('.page_search_box').addClass('active')
    });
    $('.search_close > i').on('click', function () {
        $('.page_search_box').removeClass('active')
    });





    /* ---------------------------------------------
        Sticky Fixed Menu
    --------------------------------------------- */

    $(window).scroll(function () {
        var window_top = $(window).scrollTop() + 1;

        if (window_top > 50) {
            $('.fixed-btm-top').addClass('reveal');
        } else {
            $('.fixed-btm-top').removeClass('reveal');
        }
    });

    //  Sticky Menu

    $(window).scroll(function () {
        var window_top = $(window).scrollTop() + 1;
        //if (window_top > 50) {
        //    $('.navbar-sticky').addClass('menu_fixed animated fadeInDown');
        //} else {
        //    $('.navbar-sticky').removeClass('menu_fixed animated fadeInDown');
        //}
    });


    //  Lightbox
    $('.popup').magnificPopup({
        type: 'image',
        gallery: {
            enabled: true
        },
        removalDelay: 300,
    });


    ///* ---------------------------------------------
    //      Course filtering
    //--------------------------------------------- */
    //var $courses = $('.course-gallery');
    //if ($.fn.imagesLoaded && $portfolio.length > 0) {
    //    imagesLoaded($courses, function () {
    //        $courses.isotope({
    //            itemSelector: '.course-item',
    //            filter: '*'
    //        });
    //        $(window).trigger("resize");
    //    });
    //}

    //$('.course-filter').on('click', 'a', function (e) {
    //    e.preventDefault();
    //    $(this).parent().addClass('active').siblings().removeClass('active');
    //    var filterValue = $(this).attr('data-filter');
    //    $courses.isotope({ filter: filterValue });
    //});


}(jQuery));

$(document).ready(function () {
    const counterUp = window.counterUp.default;

    const callback = entries => {
        entries.forEach(entry => {
            const el = entry.target
            if (entry.isIntersecting && !el.classList.contains('is-visible')) {
                counterUp(el, {
                    duration: 1000,
                    delay: 50,
                });
                el.classList.add('is-visible');
            }
        });
    };

    const IO = new IntersectionObserver(callback, { threshold: 1 });

    const counters = document.getElementsByClassName('counter');

    for (const counter of counters) {
        IO.observe(counter);
    }
});