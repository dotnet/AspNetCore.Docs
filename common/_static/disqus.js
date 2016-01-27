$(function(){
  var button = $('#showComments');
  
  if (button.length)
  {
    var handler = function(){
      /* * * CONFIGURATION VARIABLES: EDIT BEFORE PASTING INTO YOUR WEBPAGE * * */
      var disqus_shortname = 'aspnetdocs'; // required: replace example with your forum shortname

      /* * * DON'T EDIT BELOW THIS LINE * * */
      var dsq = document.createElement('script'); dsq.type = 'text/javascript'; dsq.async = true;
      dsq.src = 'https://' + disqus_shortname + '.disqus.com/embed.js';
      (document.getElementsByTagName('head')[0] || document.getElementsByTagName('body')[0]).appendChild(dsq);
      
      button.hide();
    };
    
    button.on("click", handler);
  }
});