function reMap(smallObject, contract) {
    var largeObject = {};
    for (var smallProperty in contract) {
        largeObject[contract[smallProperty]] = smallObject[smallProperty];
    }
    return largeObject;
}
var shapeModelContract = {
    l: "left",
    t: "top"
};
myHub.client.setShape = function (shapeModelSmall) {
    var shapeModel = reMap(shapeModelSmall, shapeModelContract);
    // shapeModelSmall has "l" and "t" properties  but after remapping
    // shapeModel now has "left" and "top" properties
};