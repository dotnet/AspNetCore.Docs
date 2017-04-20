<ajaxToolkit:AnimationExtender ID="ae" runat="server"
 TargetControlID="Panel1">
 <Animations>
 <OnLoad>
 <Sequence>
 <Condition ConditionScript="Math.random()   0.5">
 <Resize Width="1000" Height="150" Unit="px" />
 </Condition>
 <Condition ConditionScript="Math.random()   0.5">
 <FadeOut Duration="1.5" Fps="24" />
 </Condition>
 </Sequence>
 </OnLoad>
 </Animations>
</ajaxToolkit:AnimationExtender>