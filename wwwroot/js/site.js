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

if ($("#cart-count").html() != "0") {
  $("#cart-count").css("display", "block");
}

$('#cart-count').on('DOMSubtreeModified', function () {
  if ($("#cart-count").html() != "0") {
    $("#cart-count").css("display", "block");
  }
});

function updateCartItems() {
  $.ajax({
    url: '/Home/GetCartItems',
    type: 'GET',
    success: function (data) {
      // Clear existing cart items
      $('#cart-items').empty();

      // Populate new cart items
      if (data.equipment && data.equipment.length > 0) {
        data.equipment.forEach(function (item) {
          console.log(data);
          $('#cart-items').append('<label>' + item.name + '</label><br>');
        });
      }

      if (data.suits && data.suits.length > 0) {
        data.suits.forEach(function (item) {
          $('#cart-items').append('<label>' + item.name + '</label><br>');
        });
      }

      if (data.addons && data.addons.length > 0) {
        data.addons.forEach(function (item) {
          $('#cart-items').append('<label>' + item.name +'</label><br>');
        });
      }
    },
    error: function () {
      alert('Failed to retrieve cart items.');
    }
  });
}

$(document).ready(function () {
  updateCartItems(); // Load cart items on page load
});