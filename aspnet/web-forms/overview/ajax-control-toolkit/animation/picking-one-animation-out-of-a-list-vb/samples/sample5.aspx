<ajaxToolkit:AnimationExtender ID="ae" runat="server"
 TargetControlID="Panel1">
 <Animations>
 <OnLoad>
 <Case SelectScript="Math.floor(3 * Math.random())">
 <Resize Width="1000" Unit="px" />
 <Resize Height="150" Unit="px" />
 <FadeOut Duration="1.5" Fps="24" />
 </Case>
 </OnLoad>
 </Animations>
</ajaxToolkit:AnimationExtender>