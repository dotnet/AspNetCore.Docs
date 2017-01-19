protected void Page_Load(object sender, EventArgs e) {
    TextBox1.ToolTip = Column.Description;
            
    SetUpValidator(RequiredFieldValidator1);
    SetUpValidator(RegularExpressionValidator1);
    SetUpValidator(DynamicValidator1);
    SetUpCustomValidator(DateValidator);

    RangeAttribute ra = (RangeAttribute)Column.Attributes[typeof(RangeAttribute)];
    if (ra != null)
    {
        t1.MinDate = ra.Minimum.ToString();
        t1.MaxDate = ra.Maximum.ToString();
    }
}