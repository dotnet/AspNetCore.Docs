cls
set xdir=/XD  2 debug bin rm artifacts node_modules wwwroot .git _build build
REM remove node_modules wwwroot  on 2nd pass
REM set xdir=/XD  2 debug bin rm artifacts 
set xf=/XF *.dll *.exe  *.pst *.tmp *.zip *.url *.mny *.wci *.obj Thumbs.db *.html .git* *.txt *.md
set opt=/E  /R:1 /W:0 /REG /A+:R 

set src=.

set trg=\\rl5\c$\Users\riande\Documents\GitHub\Docs\aspnet\fundamentals\localization\sample
robocopy %src%  %trg%  %opt% %xdir% %XF% 

set trg=\\rl5\c$\Dropbox\bak\rc2
robocopy %src%  %trg%  %opt% %xdir% %XF%  

