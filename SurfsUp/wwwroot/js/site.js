// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function goTo(id) {
  let destination = document.querySelector(id);
  let yCoord = destination.offsetTop - 80;
  window.scrollTo({
    top: yCoord,
    behavior: "smooth"
  });
}

const carouselElement = document.querySelector('#surf-carousel')

const carousel = new bootstrap.Carousel(carouselElement, {
  interval: 7500,
  touch: false
})
