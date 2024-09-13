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

function limitTime(date) {
  let currTime  = `${date}`.split("T")[1].split(":");
  let hour      = parseInt(currTime[0]);
  let minute    = parseInt(currTime[1]);

  let rounded   = Math.round(((hour * 60) + minute) / 15) * 15;
  let roundHour = ''+Math.floor(rounded / 60);
  let roundMin  = ''+rounded%60;

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

// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
  if (event.target == modal) {
    modalClose();
  }
}

function submitBooking() {
  $.ajax({
    url: '/Book/AddBooking',
    type: 'POST',
    data: {
      firstName: $("#FirstName").val(),
      lastName: $("#LastName").val(),
      time: $("#Time").val(),
      phone: $("#Phone").val(),
      email: $("#Email").val()
    },
    success: function (response) {
      if (response.message === "Booking added!") {
        booking = response.booking;
        cart = booking.equipment;

        $("#booking-id").html(booking.id);
        $("#booking-first-name").val(booking.firstName);
        $("#booking-last-name").val(booking.lastName);
        $("#booking-time").val(booking.time);
        $("#booking-phone").val(booking.phone);
        $("#booking-email").val(booking.email);
       
        
        if (cart.equipment && cart.equipment.length > 0) {
          cart.equipment.forEach(function (item) {
            $('#booking-items').append('<label>' + item.name +'</label><br>');
          });
        }
  
        if (cart.suits && cart.suits.length > 0) {
          cart.suits.forEach(function (item) {
            $('#booking-items').append('<label>' + item.name +'</label><br>');
          });
        }
  
        if (cart.addons && cart.addons.length > 0) {
          cart.addons.forEach(function (item) {
            $('#booking-items').append('<label>' + item.name +'</label><br>');
          });
        }

        modal.css("display", "block");
      }
    },
    error: function () {
      alert('Din booking fejlede');
    }
  });
}

function modalClose() {
  modal.css("display", "none");
}
