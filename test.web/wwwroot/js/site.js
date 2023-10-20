// Function to fetch and display other user locations
function updateOtherUserLocations() {
    $.get('@Url.Action("GetOtherUserLocations", "Location")', function (data) {
        // Assuming data is an array of user locations with { UserID, Latitude, Longitude }
        for (var i = 0; i < data.length; i++) {
            var userLocation = data[i];
            // Display the user's location on the map or as needed
            displayUserLocationOnMap(userLocation);
        }
    });
}

// Call the updateOtherUserLocations function periodically (every second)
$(document).ready(function () {
    // Call it immediately upon page load
    updateOtherUserLocations();

    // Then call it periodically to update locations
    setInterval(updateOtherUserLocations, 1000);
});
