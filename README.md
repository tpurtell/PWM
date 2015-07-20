# WARNING: USE AT YOUR OWN RISK
Adjusting the value from the default may affect the lifetime of the lamp in your screen.  You might end up looking into the abyss.  You have been WARNED!

# PWM
This is a utility to allow for adjust the PWM driver frequency delivered from Intel Graphics embedded GPU to the embedded LCD panel.  It shows you the existing value and lets you pick a new one.

It was inspired by this 
https://wiki.archlinux.org/index.php/Backlight#Backlight_PWM_modulation_frequency_.28Intel_i915_only.29
and this
http://devbraindom.blogspot.com/2013/03/eliminate-led-screen-flicker-with-intel.html
But its for Windows x64 instead.  

I think the value it reads back and writes is the frequency in Hz.  The actual output was not checked via high speed camera or anything like that, but it seems to have the same behavior as sending those intel_reg_write commands from linux with the computed values.  The driver actually has two configuration DWORDs,  the default for me for these two values in decimal is 2 and 200.  This utility just keeps the first value as read back from the driver and changes only the second value.  It's possible the first value is duty cycle or mode related, or something completely different.  You could experiment using the source code if you aren't afraid to explode.

# LICENSE
Public domain
