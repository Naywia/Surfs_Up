﻿function goTo(id) {
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
          $('#cart-items').append('<label>' + item.name + '</label><br>');
        });
      }
    },
    error: function () {
      alert('Failed to retrieve cart items.');
    }
  });
}

function limitTime(date) {
  let currTime = `${date}`.split("T")[1].split(":");
  let hour = parseInt(currTime[0]);
  let minute = parseInt(currTime[1]);

  let rounded = Math.round(((hour * 60) + minute) / 15) * 15;
  let roundHour = '' + Math.floor(rounded / 60);
  let roundMin = '' + rounded % 60;

  let result = `${roundHour}:${roundMin.padStart(2, '0')}`;
  return `${date}`.replace(`${currTime[0]}:${currTime[1]}`, result);
}

$(document).ready(function () {
  updateCartItems(); // Load cart items on page load

  // Dette er fra denne søde mand på Stack'en
  // https://stackoverflow.com/questions/24468518/html5-input-datetime-local-default-value-of-today-and-current-time
  const today = new Date();
  const localDate = new Date(today - today.getTimezoneOffset() * 60000);  // This converts the time to the actual current time
  localDate.setSeconds(null);
  localDate.setMilliseconds(null);

  var dateTime = $("#date-form")[0];
  dateTime.value = limitTime(localDate.toISOString().slice(0, -1));

  dateTime.onchange = () => {
    dateTime.value = limitTime(dateTime.value);
  };
});

// Get the modal
var modal = $('#booking-confirmation');

$(modal).on("click", function () {
  modalClose();
});

function modalClose() {
  modal.removeClass("show")
}
