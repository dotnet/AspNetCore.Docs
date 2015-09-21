echo "Trying to build the aspnet directory..." && cd aspnet && sphinx-build -nW -b html -d _build/doctrees . _build/html
echo "Trying to build the mvc directory..." && cd ../mvc && sphinx-build -nW -b html -d _build/doctrees . _build/html
