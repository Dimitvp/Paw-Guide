$(function () {

    //$(function () {
    //    $("#SelectedVendor").on("change", function (){
    //        $("#SelectedvendorText").val($(this).text());
    //    });
    //});

    $.ajax({
        type: "GET",
        url: "business/businesses/AllLocations",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function initMap(data) {
            var location = new google.maps.LatLng(42.76314587, 25.14770508);

            var mapCanvas = document.getElementById('map');
            var mapOptions = {
                center: location,
                zoom: 8,
                panControl: true,
                scrollwheel: true,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            }
            var map = new google.maps.Map(mapCanvas, mapOptions);

            var markerImage = '/img/pawMarker.png';

            var marker, latLocation, lngLocation, city, id, name, petType, type, picUrl;

            $.each(data,
                function (key, business) {
                    city = business.city;
                    id = business.id;
                    latLocation = business.latLocation;
                    lngLocation = business.lngLocation;
                    name = business.name;
                    type = business.type;
                    petType = business.petType;
                    picUrl = business.picUrl;

                    marker = new google.maps.Marker({
                        position: new google.maps.LatLng(latLocation, lngLocation),
                        map: map,
                        icon: markerImage
                    });
                    switch (type) {
                        case 0:
                            type = 'Entertainment place';
                            break;
                        case 1:
                            type = 'Hotel';
                            break;
                        case 2:
                            type = 'Private House';
                            break;
                        case 3:
                            type = 'Camping';
                            break;
                        case 4:
                            type = 'Cabin';
                            break;
                        case 5:
                            type = 'Other Type';
                            break;
                        default:
                            type = 'No such a type of business!';
                    };
                    switch (petType) {
                        case 1:
                            petType = 'Small Breed Dog';
                            break;
                        case 2:
                            petType = 'All Dogs';
                            break;
                        case 4:
                            petType = 'Cats';
                            break;
                        case 8:
                            petType = 'Other Type';
                            break;
                            //TODO
                        default:
                            petType = 'Different kinds of Animal!';
                    };
                    var contentString = '<div class="info-window text-center">' +
                        '<h1><a href="http://localhost:9288/business/businesses/Details/'+ id +'">' + name + '</a></h1>' +
                        '<img class="img-fluid" style="max-width: 100%; height: auto;" src="' + picUrl + '"/>'+
                        '<h3>' + city + '</h3>' +
                        '<div class="info-content">' +
                        '<p>' +
                        type +
                        '<br/>' +
                        petType +
                        '</p>' +
                        '</div>' +
                        '</div>';

                    var infowindow = new google.maps.InfoWindow({
                        content: contentString,
                        maxWidth: 400
                    });

                    google.maps.event.addListener(marker, 'click', (function (marker, business) {
                        return function () {
                            infowindow.open(map, marker);
                        }
                    })(marker, business));
                });
           
            var styles = [
                {
                    "featureType": "landscape",
                    "stylers": [
                        {
                            "saturation": -100
                        },
                        {
                            "lightness": 65
                        },
                        {
                            "visibility": "on"
                        }
                    ]
                },
                {
                    "featureType": "poi",
                    "stylers": [
                        {
                            "saturation": -100
                        },
                        {
                            "lightness": 51
                        },
                        {
                            "visibility": "simplified"
                        }
                    ]
                },
                {
                    "featureType": "road.highway",
                    "stylers": [
                        {
                            "saturation": -100
                        },
                        {
                            "visibility": "simplified"
                        }
                    ]
                },
                {
                    "featureType": "road.arterial",
                    "stylers": [
                        {
                            "saturation": -100
                        },
                        {
                            "lightness": 30
                        },
                        {
                            "visibility": "on"
                        }
                    ]
                },
                {
                    "featureType": "road.local",
                    "stylers": [
                        {
                            "saturation": -100
                        },
                        {
                            "lightness": 40
                        },
                        {
                            "visibility": "on"
                        }
                    ]
                },
                {
                    "featureType": "transit",
                    "stylers": [
                        {
                            "saturation": -100
                        },
                        {
                            "visibility": "simplified"
                        }
                    ]
                },
                {
                    "featureType": "administrative.province",
                    "stylers": [
                        {
                            "visibility": "off"
                        }
                    ]
                },
                {
                    "featureType": "water",
                    "elementType": "labels",
                    "stylers": [
                        {
                            "visibility": "on"
                        },
                        {
                            "lightness": -25
                        },
                        {
                            "saturation": -100
                        }
                    ]
                },
                {
                    "featureType": "water",
                    "elementType": "geometry",
                    "stylers": [
                        {
                            "hue": "#ffff00"
                        },
                        {
                            "lightness": -25
                        },
                        {
                            "saturation": -97
                        }
                    ]
                }
            ];

            map.set('styles', styles);

            //google.maps.event.addDomListener(window, 'load', initMap);

            //var markerCluster = new MarkerClusterer(map, marker,
            //    { imagePath: 'https://developers.google.com/maps/documentation/javascript/examples/markerclusterer/m' });

        }, //End of AJAX Success function  


        //failure: function (data) {
        //    alert(data.responseText);
        //}, //End of AJAX failure function  
        //error: function (data) {
        //    alert(data.responseText);
        //} //End of AJAX error function  
    });
});