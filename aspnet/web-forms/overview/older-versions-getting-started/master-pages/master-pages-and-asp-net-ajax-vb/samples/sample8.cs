var timerEnabled = true;
function ToggleTimer(btn, timerID)
{
	// Toggle the timer enabled state
	timerEnabled = !timerEnabled;

	// Get a reference to the Timer
	var timer = $find(timerID);

	if (timerEnabled)
	{
		// Start timer
		timer._startTimer();

		// Immediately raise a tick
		timer._raiseTick();

		btn.value = 'Pause';
	}
	else
	{
		// Stop timer
		timer._stopTimer();

		btn.value = 'Resume';
	}
}