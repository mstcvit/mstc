sr.reveal('.foo', { duration: 2000, delay: 500 });
sr.reveal('.bar', { duration: 2000, delay: 500 });

$(document).ready(function(){
        $('.your-class').slick({
            setting-name: setting-value
  });
});

$('.center').slick({
    centerMode: true,
    centerPadding: '60px',
    slidesToShow: 3,
    responsive: [
        {
            breakpoint: 768,
            settings: {
                arrows: false,
                centerMode: true,
                centerPadding: '40px',
                slidesToShow: 3
            }
        },
        {
            breakpoint: 480,
            settings: {
                arrows: false,
                centerMode: true,
                centerPadding: '40px',
                slidesToShow: 1
            }
        }
    ]
});
