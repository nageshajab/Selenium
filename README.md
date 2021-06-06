
# Selenium
**app config**: url, username and password

**Single Responsibility Classes**:  For each page a new class will be added like Home, Login. All tests related to that page will go in that class.

**Logger** class which has methods to log msgs to file and also print log to console. Contains 2 main methods info and error. 

**Selenium**: Created Selenium class which has all selenium methods such as to find element, moveToElement, wait for element. No other class should be making direct calls to third party dll selenium
