// Write your Javascript code.
$(document).ready(function () {
    // Add smooth scrolling to all links
    $("a").on('click', function (event) {

        // Make sure this.hash has a value before overriding default behavior
        if (this.hash !== "") {
            // Prevent default anchor click behavior
            event.preventDefault();

            // Store hash
            var hash = this.hash;

            // Using jQuery's animate() method to add smooth page scroll
            // The optional number (800) specifies the number of milliseconds it takes to scroll to the specified area
            $('html, body').animate({
                scrollTop: $(hash).offset().top
            }, 800, function () {

                // Add hash (#) to URL when done scrolling (default click behavior)
                window.location.hash = hash;
            });
        } // End if
    });
});

// Navbar- Scroll Behavior
$(document).ready(function () {
    function onScroll() {
        var scroll = $(window).scrollTop();
        if (scroll > 50) {
            $(".navbar-inverse").css("background", "#e6e6e6");
            $(".navbar-inverse").css("border-color", "#e6e6e6");
        }

        else {
            $(".navbar-inverse").css("background", "transparent");
            $(".navbar-inverse").css("border-color", "transparent");
        }
    }

    $(window).scroll(onScroll);

    onScroll();
})