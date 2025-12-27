$(document).ready(function () {
    const today = new Date(); // Get today's date

    $('#dateRange').datepicker({
        range: true,
        minDate: today,
        multipleDatesSeparator: ' - ',
        language: 'en',
    });

    const observer = new IntersectionObserver(entries => {
        // Loop over the entries
        entries.forEach(entry => {
            // If the element is visible
            if (entry.isIntersecting) {
                // Add the appropriate animation class based on the element's trigger class
                if (entry.target.classList.contains('animation-trigger-slideInBottom')) {
                    entry.target.classList.add('slideInBottom');
                } else if (entry.target.classList.contains('animation-trigger-fadeIn')) {
                    entry.target.classList.add('fadeIn');
                }
                // Stop observing the current target to prevent re-triggering the animation
                observer.unobserve(entry.target);
            }
        });
    });

    // Select all elements with the respective animation trigger classes
    const animationTriggers = document.querySelectorAll('.animation-trigger-slideInBottom');
    const fadeInAnimation = document.querySelectorAll('.animation-trigger-fadeIn');

    // Observe each element with the slideInBottom animation trigger class
    animationTriggers.forEach(trigger => {
        observer.observe(trigger);
    });

    // Observe each element with the fadeIn animation trigger class
    fadeInAnimation.forEach(trigger => {
        observer.observe(trigger);
    });
});

document.addEventListener("DOMContentLoaded", () => {
    function formatDate(date) {

        date = new Date(date)
        const year = date.getFullYear();
        const month = String(date.getMonth() + 1).padStart(2, '0');
        const day = String(date.getDate()).padStart(2, '0');
        return `${year}-${month}-${day}`;
    };

    let query = document.querySelector.bind(document)
    let querys = document.querySelectorAll.bind(document)
    /*this.put(dataPost, this.key)
        .then((result) => {
            console.log('Do something with the result:', result);
        })
        .catch((error) => {
            console.error('Handle error:', error);
        });*/
    class HttpResquetClient {
        headers
        urlApi
        constructor(urlApi) {
            this.headers = {
                'Content-Type': 'application/json',
            }
            this.urlApi = urlApi

        }

        getDynamic() {
            let url = this.urlApi
            return new Promise(async (resolve, reject) => {
                try {
                    const response = await fetch(url, {
                        method: 'GET',
                        headers: this.headers
                    });
                    if (!response.ok) {
                        throw new Error(`HTTP error! Status: ${response.status}`);
                    }
                    const responseData = await response.json();
                    resolve(responseData);
                } catch (error) {
                    console.error('Error during PUT request:', error);
                    reject(error);
                }
            });
        }
    }

    //active
    let pages = document.querySelectorAll('.current-page-js');
    pages.forEach(page => {
        let pathname = location.pathname.toLowerCase();
        let current_page = page.href.toLowerCase().replace(location.origin, "");

        // Checking page
        if (pathname === current_page || (pathname.startsWith(current_page) && current_page !== '/')) {
            page.classList.add("active");
        } else {
            page.classList.remove("active");
        }
    });


    if (query("#header-js")) {
        activeHeader()
        function activeHeader() {
            const verticalScrollPx = window.scrollY || window.pageYOffset;

            if (verticalScrollPx < 60) {
                query("#header-js").querySelector("#header-bottom-js").classList.remove("scroll-active")
            }
            else {
                query("#header-js").querySelector("#header-bottom-js").classList.add("scroll-active")

            }
        }

        window.addEventListener('scroll', () => {
            activeHeader()
        });
    }

    //HOME JS

    if (query(".rooms-slider")) {
        const swiper = new Swiper('.rooms-slider', {
            slidesPerView: 4.6,
            spaceBetween: 10,
            breakpoints: {
                100: {
                    slidesPerView: 1,
                    spaceBetween: 0,
                },
                400: {
                    slidesPerView: 1.25,
                    spaceBetween: 0,
                },
                600: {
                    slidesPerView: 2.2,
                    spaceBetween: 0,
                },
                992: {
                    slidesPerView: 3.2,
                    spaceBetween: 0,
                },
                1200: {
                    slidesPerView: 3.5,
                    spaceBetween: 0,
                },
                1500: {
                    slidesPerView: 4.5,
                    spaceBetween: 0,
                },
            },
            centeredSlides: false,
            spaceBetween: 0, // Adjust spacing between cards
            loop: true,
        });
    }

    if (query(".tours-slider")) {
        const swiper = new Swiper('.tours-slider', {
            slidesPerView: 1,
            speed: 400,
            grabCursor: true,
            effect: 'coverflow',
            breakpoints: {
                400: {
                    slidesPerView: 1.25,
                    centeredSlides: true,
                },
                500: {
                    slidesPerView: 1.5,
                    centeredSlides: true,
                },
                700: {
                    slidesPerView: 2.2,
                    centeredSlides: true,
                },
                820: {
                    slidesPerView: 2.4,
                    centeredSlides: true,
                },
                992: {
                    slidesPerView: 3,
                    centeredSlides: true,
                },
            },
            spaceBetween: 20, // Adjust spacing between cards
            loop: true,
            coverflowEffect: {
                rotate: 0,
                stretch: 0,
                slideShadows: false, // Show shadows
            },
        });
    }

    if (query(".review-slider")) {
        const swiper = new Swiper('.review-slider', {
            slidesPerView: 1,
            breakpoints: {
                400: {
                    slidesPerView: 1.25,
                },
                600: {
                    slidesPerView: 2.25,
                },
                992: {
                    slidesPerView: 2.5,
                }
                ,
                1200: {
                    slidesPerView: 3,
                }
            },
            spaceBetween: 20, // Adjust spacing between cards
            loop: false,
        });
    }

    if (query(".gallery-slider")) {
        const swiper = new Swiper('.gallery-slider', {
            freeMode: true,
            slidesPerView: 1,
            breakpoints: {
                400: {
                    slidesPerView: 1.25,
                },
                600: {
                    slidesPerView: 2,
                },
                992: {
                    slidesPerView: 3,
                }
                ,
                1200: {
                    slidesPerView: 3.5,
                }
            },
            spaceBetween: 0, // Adjust spacing between cards
            loop: false,
        });
    }

    //BLOG JS
    if (query(".highlight-slider")) {
        const swiper = new Swiper('.highlight-slider', {
            slidesPerView: 1,
            spaceBetween: 10, // Adjust spacing between cards
            loop: false,
            pagination: {
                el: '.swiper-pagination',
            },
        });
    }

    if (query(".blog-rooms-slider")) {
        const swiper = new Swiper('.blog-rooms-slider', {
            slidesPerView: 1,
            spaceBetween: 0,
            breakpoints: {
                200: {
                    slidesPerView: 1,
                    spaceBetween: 0,
                },
                400: {
                    slidesPerView: 1.25,
                    spaceBetween: 0,
                },
                600: {
                    slidesPerView: 1.5,
                    spaceBetween: 0,
                },
                1200: {
                    slidesPerView: 2.25,
                    spaceBetween: 0,
                },
            },
            spaceBetween: 0, // Adjust spacing between cards
            loop: true,
        });
    }

    //ROOMS JS
    if (query(".rooms-page-slider")) {
        const swiper = new Swiper('.rooms-page-slider', {
            slidesPerView: 1,
            speed: 400,
            grabCursor: true,
            effect: 'coverflow',
            breakpoints: {
                400: {
                    slidesPerView: 1.25,
                    centeredSlides: true,
                },
                500: {
                    slidesPerView: 1.5,
                    centeredSlides: true,
                },
                700: {
                    slidesPerView: 2.2,
                    centeredSlides: true,
                },
                820: {
                    slidesPerView: 2.4,
                    centeredSlides: true,
                },
                992: {
                    slidesPerView: 3,
                    centeredSlides: true,
                },
            },
            spaceBetween: 0, // Adjust spacing between cards
            loop: true,
            coverflowEffect: {
                rotate: 0,
                stretch: 0,
                slideShadows: false, // Show shadows
            },
        });
    }

    //ROOM DETAIL JS

    if (query(".room-detail-silde")) {
        const swiper = new Swiper('.room-detail-silde', {
            slidesPerView: 1,
            breakpoints: {
                400: {
                    slidesPerView: 1.25,
                },
                600: {
                    slidesPerView: 1.5,
                }
            },
            spaceBetween: 20, // Adjust spacing between cards
            loop: false,
        });
    }

    //TOURS JS
    if (query(".tour-page-slider")) {
        const swiper = new Swiper('.tour-page-slider', {
            slidesPerView: 1,
            speed: 400,
            grabCursor: true,
            effect: 'coverflow',
            breakpoints: {
                400: {
                    slidesPerView: 1.25,
                    centeredSlides: true,
                },
                500: {
                    slidesPerView: 1.5,
                    centeredSlides: true,
                },
                700: {
                    slidesPerView: 2.2,
                    centeredSlides: true,
                },
                820: {
                    slidesPerView: 2.4,
                    centeredSlides: true,
                },
                992: {
                    slidesPerView: 3,
                    centeredSlides: true,
                },
            },
            spaceBetween: 0, // Adjust spacing between cards
            loop: true,
            centeredSlides: true,
            coverflowEffect: {
                rotate: 0,
                stretch: 0,
                slideShadows: false, // Show shadows
            },
        });
    }

    //TOUR DETAIL JS

    if (query(".tour-detail-silde")) {
        const swiper = new Swiper('.tour-detail-silde', {
            slidesPerView: 1,
            breakpoints: {
                400: {
                    slidesPerView: 1.25,
                },
                600: {
                    slidesPerView: 1.5,
                }
            },
            spaceBetween: 20, // Adjust spacing between cards
            loop: false,
        });
    }

})