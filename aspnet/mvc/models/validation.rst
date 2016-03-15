Model Validation
=============

By `Pawan Jha <http://github.com/PawanKJ>`_

In this article

- `Introduction to model validation`_
- `How model validation works`_


Introduction to model validation
--------------------------------
The most common application security flaws/weakness is the failure in validation from client & server side.Data from the client site should never be trusted by server for the client has every possibility to tamper with the data.So its ensure that data is not not only validated,but process of data flow should also be correct.

In this article i tried to explain how to implement strong validation rule & process in MVC web application.Here, we will see different approaches to validate data from clientside and from serverside.

How model validation works
--------------------------------
Basically, this article contains the following approaches:

#. `By using Data Annotations`
#. `By using ModelState object` 
#. `By using Custom validation`
#. `By using Remote validation`

