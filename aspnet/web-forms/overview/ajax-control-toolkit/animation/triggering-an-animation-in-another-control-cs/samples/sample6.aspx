<ajaxToolkit:AnimationExtender ID="ae" runat="server" TargetControlID="Panel1">
 <Animations>
 <OnClick>
 <Sequence>
 <EnableAction Enabled="false" />
 <Parallel>
 <FadeOut Duration="1.5" Fps="24" AnimationTarget="Panel1" />
 <Resize Width="1000" Height="150" Unit="px" 
 AnimationTarget="Panel1" />
 </Parallel>
 </Sequence>
 </OnClick>
 </Animations>
</ajaxToolkit:AnimationExtender>