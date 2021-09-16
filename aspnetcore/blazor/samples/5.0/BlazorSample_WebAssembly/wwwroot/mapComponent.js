import 'https://api.mapbox.com/mapbox-gl-js/v1.12.0/mapbox-gl.js';

mapboxgl.accessToken = 'pk.eyJ1IjoiZ3VhcmRyZXgiLCJhIjoiY2tvZnBkZmlqMGtyZTJ3bnJvdjJ0bWNhNiJ9.zvSwQMBflS5EjgC3dp4cyg';

export function addMapToElement(element) {
  return new mapboxgl.Map({
    container: element,
    style: 'mapbox://styles/mapbox/streets-v11',
    center: [-74.5, 40],
    zoom: 9
  });
}

export function setMapCenter(map, latitude, longitude) {
  map.setCenter([longitude, latitude]);
}
