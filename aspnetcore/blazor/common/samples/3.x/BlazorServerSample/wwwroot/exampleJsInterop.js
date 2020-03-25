window.exampleJsFunctions = {
  showPrompt: function (text) {
    return prompt(text, 'Type your name here');
  },
  displayWelcome: function (welcomeMessage) {
    document.getElementById('welcome').innerText = welcomeMessage;
  },
  returnArrayAsyncJs: function () {
    DotNet.invokeMethodAsync('BlazorSample', 'ReturnArrayAsync')
      .then(data => {
        data.push(4);
          console.log(data);
      });
  },
  sayHello: function (dotnetHelper) {
    return dotnetHelper.invokeMethodAsync('SayHello')
      .then(r => console.log(r));
  }
};
