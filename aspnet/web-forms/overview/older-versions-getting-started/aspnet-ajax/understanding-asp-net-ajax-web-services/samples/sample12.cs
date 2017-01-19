if (typeof(Model.Address) === 'undefined')
{
     Model.Address=gtc("Model.Address");
     Model.Address.registerClass('Model.Address');
}
Model.Gender = function() { throw Error.invalidOperation(); }
Model.Gender.prototype = {Unknown: 0,Male: 1,Female: 2}
Model.Gender.registerEnum('Model.Gender', true);