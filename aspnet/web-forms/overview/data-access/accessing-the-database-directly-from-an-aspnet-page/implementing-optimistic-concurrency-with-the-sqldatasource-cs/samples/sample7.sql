(
   ([ColumnName] IS NULL AND @original_ColumnName IS NULL)
     OR
   ([ColumnName] = @original_ColumnName)
)