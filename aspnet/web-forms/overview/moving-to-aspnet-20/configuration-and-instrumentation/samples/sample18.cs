compilation.Debug = !_debugStatus;
config.Save();
lblDebugStatus.Text = "Debug set to: " + compilation.Debug.ToString();