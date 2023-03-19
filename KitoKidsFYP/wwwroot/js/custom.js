jQuery(document).ready(function($) {
    
    var ResponsiveMenuPro = {
        trigger: '#responsive-menu-pro-button',
        animationSpeed:500,
        breakpoint:1023,        isOpen: false,
        activeClass: 'is-active',
        container: '#responsive-menu-pro-container',
        openClass: 'responsive-menu-pro-open',
        activeArrow: '<span class="fas fa-angle-down"></span>',
        inactiveArrow: '<span class="fas fa-angle-up"></span>',
        wrapper: '#responsive-menu-pro-wrapper',
        linkElement: '.responsive-menu-pro-item-link',
        subMenuTransitionTime:200,
        originalHeight: '',
        openMenu: function() {
            $(this.trigger).addClass(this.activeClass);
            $('html').addClass(this.openClass);
            $('.responsive-menu-pro-button-icon-active').hide();
            $('.responsive-menu-pro-button-icon-inactive').show();               
             this.setWrapperTranslate();
            this.isOpen = true;
        },
        closeMenu: function() {
            $(this.trigger).removeClass(this.activeClass);
            $('html').removeClass(this.openClass);
            $('.responsive-menu-pro-button-icon-inactive').hide();
            $('.responsive-menu-pro-button-icon-active').show();              
              this.clearWrapperTranslate();
            $("#responsive-menu-pro > li").removeAttr('style');
            this.isOpen = false;
        },        triggerMenu: function() {
            this.isOpen ? this.closeMenu() : this.openMenu();
        },
        triggerSubArrow: function(subarrow) {
            var sub_menu = $(subarrow).parent().siblings('.responsive-menu-pro-submenu');
            var self = this;
                if(sub_menu.hasClass('responsive-menu-pro-submenu-open')) {
                    sub_menu.slideUp(self.subMenuTransitionTime, 'linear',function() {
                        $(this).css('display', '');
                    }).removeClass('responsive-menu-pro-submenu-open');
                    $(subarrow).html(this.inactiveArrow);
                    $(subarrow).removeClass('responsive-menu-pro-subarrow-active');
                } else {
                    sub_menu.slideDown(self.subMenuTransitionTime, 'linear').addClass('responsive-menu-pro-submenu-open');
                    $(subarrow).html(this.activeArrow);
                    $(subarrow).addClass('responsive-menu-pro-subarrow-active');
                }
        },
        menuHeight: function() {
            return $(this.container).height();
        },
        menuWidth: function() {
            return $(this.container).width();
        },
        wrapperHeight: function() {
            return $(this.wrapper).height();
        },            setWrapperTranslate: function() {
                switch('right') {
                    case 'left':
                        translate = 'translateX(' + this.menuWidth() + 'px)'; break;
                    case 'right':
                        translate = 'translateX(-' + this.menuWidth() + 'px)'; break;
                    case 'top':
                        translate = 'translateY(' + this.wrapperHeight() + 'px)'; break;
                    case 'bottom':
                        translate = 'translateY(-' + this.menuHeight() + 'px)'; break;
                }            },
            clearWrapperTranslate: function() {
                var self = this;            },
        init: function() {

            var self = this;
            $(this.trigger).on('click', function(e){
                e.stopPropagation();
                self.triggerMenu();
            });

            $(this.trigger).mouseup(function(){
                $(self.trigger).blur();
            });

            $('.responsive-menu-pro-subarrow').on('click', function(e) {
                e.preventDefault();
                e.stopPropagation();
                self.triggerSubArrow(this);
            });

            $(window).resize(function() {
                if($(window).width() >= self.breakpoint) {
                    if(self.isOpen){
                        self.closeMenu();
                    }
                    $('#responsive-menu-pro, .responsive-menu-pro-submenu').removeAttr('style');
                } else {                        if($('.responsive-menu-pro-open').length > 0){
                            self.setWrapperTranslate();
                        }                }
            });
        }
    };
    ResponsiveMenuPro.init();
});
