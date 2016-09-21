[![Build Status](https://travis-ci.org/fisenkodv/designpatterns.svg?branch=master)](https://travis-ci.org/fisenkodv/designpatterns)

INTRODUCTION
============
Below you can find three basic classifications of patterns: Creational, Structural, and Behavioral.

TYPES OF DESIGN PATTERN
========================
There are three basic kinds of design patterns:
* Structural
* Behavioral
* Creational

Structural: Generally deal with relationships between entities, making it easier for these entities to work together.
Creational: Provide instantiation mechanisms, making it easier to create objects in a way that suits the situation.
Behavioral: Are used in communications between entities and make it easier and more flexible for these entities to communicate.

1. Structural Patterns 
=======================
Adapter					=	Match interfaces of different classes. 
Bridge					=	Separates an object’s abstraction from its implementation. 
Composite				=	A tree structure of simple and composite objects. 
Decorator				=	Add responsibilities to objects dynamically. 
Façade					=	A single class that represents an entire subsystem.
Flyweight				=	A fine=grained instance used for efficient sharing. 
Proxy				   	=	An object representing another object.

2. Behavioral Patterns 
=======================
Chain of Responsibility	=	A way of passing a request between a chain of objects.
Iterator				=	Sequentially access the elements of a collection. 
Mediator				=	Defines simplified communication between classes.
Memento					=	Capture and restore an object's internal state. 
Observer:				=	A way of notifying change to a number of classes. 
State					=	Alter an object's behavior when its state changes. 
Strategy				=	Encapsulates an algorithm inside a class. 
Template Method			=	Defer the exact steps of an algorithm to a subclass. 
Visitor					=	Defines a new operation to a class without change.

3.Creational Patterns
======================
Abstract Factory		=	 Creates an instance of several families of classes.
Builder:				=	 Separates object construction from its representation.
Factory Method			=	 Creates an instance of several derived classes.
Prototype				=	 A fully initialized instance to be copied or cloned.
Singleton				=	 A class in which only a single instance can exist.

1.1 ADAPTER PATTERN
--------------------
The Adapter pattern is used to convert the programming interface of one class into that of another. We use
adapters whenever we want unrelated classes to work together in a single program. The concept of an adapter is
thus pretty simple: We write a class that has the desired interface and then make it communicate with the class
that has a different interface.

* Convert the interface of a class into another interface clients expect.
* Adapter lets classes work together, that could not otherwise because of incompatible interfaces.

Example:

In this example, We want to build functionality for Remote desktop connection.
"IMyRemoteDesktop" interface tells the functionality which i need to accomplish in remote connection.
So, "MyRemoteDestopWrapper" class was extended from "IMyRemoteDesktop" interface and written with the logic
for remote connection. At the same time, we want to use Real VNC API to write another logic to connect to remote desktop.
So, using adapter pattern, "IMyRemoteDesktop" was extended to "RealVNCRemoteDesktopAdapter" and fit the Real VNC
functionality to make it to work together.

1.2 BRIDGE PATTERN
-------------------
At first sight, the Bridge pattern looks a lot like the Adapter pattern in that a class is used to convert one kind of
interface to another. However, the intent of the Adapter pattern is to make one or more classes' interfaces look
the same as that of a particular class. The Bridge pattern is designed to separate a class's interface from its
implementation so you can vary or replace the implementation without changing the client code.

* The intent of this pattern is to decouple abstraction from implementation so that the two can vary independently.

Example:

In this example, We want to build Remote Control fuctionality for Televisions.
The functionality for remote controller is same for any brand or model of television.
"RemoteControl" abstract class was build that accepts television object using SetTelevision().
"RemoteController" class extends from "RemoteControl" class acts accordingly for On/Off/Change channel
for any kind of television that extended from ITelevision.

1.3 COMPOSITE PATTERN
----------------------
A component in object orientation may be either an individual object or acollection of objects. 
The Composite pattern is designed to accommodate both cases. You can use the Composite
to build part-whole hierarchies or to construct data representations of trees. In summary, a composite is a
collection of objects, any one of which may be either a composite or just a primitive object. In tree nomenclature,
some objects may be nodes with additional branches and some may be leaves.

* The intent of this pattern is to compose objects into tree structures to represent part-whole hierarchies.
* Composite lets clients treat individual objects and compositions of objects uniformly.

Example:

In this example, "IEmployee" interface is extended to "Branch" or "Leaf" class.
Where as "Branch" is composite of objects that holds reportees and "Leaf" are primitive object that has no reportees.
But, both "Branch" and "Leaf" class are treated uniformly.

1.4 DECORATOR PATTERN
----------------------
The Decorator pattern provides us with a way to modify the behavior of individual objects without having to
create a new derived class. Suppose we have a program that uses eight objects, but three of them need an
additional feature. You could create a derived class for each of these objects, and in many cases this would be a
perfectly acceptable solution. However, if each of these three objects requires different features, this would mean
creating three derived classes. Further, if one of the classes has features of both of the other classes, you begin
to create complexity that is both confusing and unnecessary.

* The intent of this pattern is to add additional responsibilities dynamically to an object.

Example:

In this example, "Pizza" class tells basic cost and description of Pizza. "PizzaTpoings" is a decorator class that add
reponsibility by extending to other class like "ExtraCheese", "ExtraSoya" to append description and cost.

1.5 FACADE PATTERN
-------------------
The Façade pattern is used to wrap a set of complex classes into a simpler enclosing interface. As your programs
evolve and develop, they grow in complexity. In fact, for all the excitement about using design patterns, these
patterns sometimes generate so many classes that it is difficult to understand the program's flow. Furthermore,
there may be a number of complicated subsystems, each of which has its own complex interface.

* Simplify the complexity by providing a simplified interface to these subsystems

Example:

In this example, To order a product few sub-systems involved in it like choosing a product, payment gateway and invoice.
All the sub-systems are falicitated by "OrderFacade" class that contains "PlaceOrder()" method.

1.6 FLY-WEIGHT PATTERN
-----------------------
The Flyweight pattern is used to avoid the overhead of large numbers of very similar classes. There are cases in
programming where it seems that you need to generate a very large number of small class instances to
represent data. Sometimes you can greatly reduce the number of different classes that you need to instantiate if
you can recognize that the instances are fundamentally the same except for a few parameters. If you can move
those variables outside the class instance and pass them in as part of a method call, the number of separate
instances can be greatly reduced by sharing them.

* The intent of this pattern is to use sharing to support a large number of objects that have part of their 
internal state in common where the other part of state can vary.

Example:

In this example, To print the business card for an organization, Address is common for all employees.
The things going to change is Name, Designation, Department, etc. So, Address object holds as a static property that used for
all employees business cards to reduce the weight of business card object.

1.7 PROXY PATTERN
------------------
The Proxy pattern is used when you need to represent an object that is complex or time consuming to create
with a simpler one. If creating an object is expensive in time or computer resources, Proxy allows you to
postpone this creation until you need the actual object. A Proxy usually has the same methods as the object it
represents, and once the object is loaded, it passes on the method calls from the Proxy to the actual object.

* The intent of this pattern is to provide a placeholder for an object to control references to it.

Example:

In this example, To make a payment, payment can be of any form like Cheque leaf or Online transfer.
Both "ChequeProxy" and "OnlienFundProxy" extended from "IPayment" interface to make the payment.

2.1 CHAIN-OF-RESPONSIBILITY PATTERN
------------------------------------
The Chain of Responsibility pattern allows a number of classes to attempt to handle a request without any of
them knowing about the capabilities of the other classes. It provides a loose coupling between these classes; the
only common link is the request that is passed between them. The request is passed along until one of the
classes can handle it.

* It avoids attaching the sender of a request to its receiver, giving this way other objects the possibility of handling the request too.
* The objects become parts of a chain and the request is sent from one object to another across the chain until one of the objects will handle it.

Example:

In this example, If an employee wants to submit Reimbursement for official expenses. He will be submitting to his manager.
Depends on amount spent, either manager can approve it or it will be escalated to Senior Manager or it will again escalate to Director
if amount is too high. Here, object gets changed depends on escalation level.

2.2 ITERATOR PATTERN
---------------------
The Iterator is one of the simplest and most frequently used of the design patterns. The Iterator pattern allows
you to move through a list or collection of data using a standard interface without having to know the details of
the internal representations of that data. In addition, you can also define special iterators that perform some
special processing and return only specified elements of the data collection.

* Provide a way to access the elements of an aggregate object sequentially without exposing its underlying representation.

Example:

In this example, Instead of creating array of objects and managing array in client program, A collection class that extended from
IEnumerable<T> (where T is an scalar object). "MedicalEquipment" is a scalar class for which "MedicalEquipmentCollection" collection class
was created to manage collection of Medical Equipments in a hospital.

2.3 MEDIATOR PATTERN
---------------------
When a program is made up of a number of classes, the logic and computation is divided logically among these
classes. However, as more of these isolated classes are developed in a program, the problem of communication
between these classes becomes more complex. The more each class needs to know about the methods of
another class, the more tangled the class structure can become. This makes the program harder to read and
harder to maintain. Further, it can become difficult to change the program, since any change may affect code in
several other classes. The Mediator pattern addresses this problem by promoting looser coupling between these
classes. Mediators accomplish this by being the only class that has detailed knowledge of the methods of other
classes. Classes inform the Mediator when changes occur, and the Mediator passes on the changes to any other
classes that need to be informed.

* Define an object that encapsulates how a set of objects interact. Mediator promotes loose coupling by 
keeping objects from referring to each other explicitly, and it lets you vary their interaction independently.

Example:

In this example, Different objects of "ChatPerson" class interchange information between itself using "Messenger" class.
"Messenger" class that extended from "IMessenger" interface facilitates/mediates communication between two different 
"ChatPerson" objects.

2.5 MEMENTO PATTERN
--------------------
Ideally, it should be possible to save and restore this state without making each object take care of this
task and without violating encapsulation. It is sometimes necessary to capture the internal state of an object 
at some point and have the ability to restore the object to that state later in time. 
Such a case is useful in case of error or failure in serial transaction scope.

* The intent of this pattern is to capture the internal state of an object without violating encapsulation and 
thus providing a mean for restoring the object into initial state when needed.

Example:

MS Calculator has option to memorize the value and retrieve value from memory. In this example, "SimpleCalculator" class 
extended from "ICalc" interface do some maths operation. "ResultsCache" used to cache the result and hold it in memory and
client program can retrieve value that cached any time for further calculation.


2.6 OBSERVER PATTERN
---------------------
All object oriented programming is about objects and their interaction. The cases when certain objects need 
to be informed about the changes occurred in other objects are frequent. To have a good design means to decouple 
as much as possible and to reduce the dependencies. The Observer Design Pattern can be used whenever a subject 
has to be observed by one or more observers.

* Defines a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically.

Example:

In this example, There is "Stock" class extended from "IStock" interface and "Investor" class extended from "IInvestor".
Investor will be subscribed to Stock object. if any change in price of "Stock" object, all "Investor" subscribed will
get notification on price update.

2.7 STATE PATTERN
------------------
The State pattern is used when you want to have an object represent the state of your application and switch
application states by switching objects. For example, you could have an enclosing class switch between a number
of related contained classes and pass method calls on to the current contained class. Design Patterns suggests
that the State pattern switches between internal classes in such a way that the enclosing object appears to
change its class.

Example:

In this example, "Account" class has the State as property. State object changed according to withdrawable balance.
Once account created newly, it will be Bronze State. Its Balance is beyond 50K, State property change to Silver state.

2.8 STRATEGY PATTERN
---------------------
The Strategy pattern is much like the State pattern in outline but a little different in intent. The Strategy pattern
consists of a number of related algorithms encapsulated in a driver class called the Context. Your client program
can select one of these differing algorithms, or in some cases, the Context might select the best one for you. The
intent is to make these algorithms interchangeable and provide a way to choose the most appropriate one. The
difference between State and Strategy is that the user generally chooses which of several strategies to apply and
that only one strategy at a time is likely to be instantiated and active within the Context class.

* Define a family of algorithms, encapsulate each one, and make them interchangeable. Strategy lets the algorithm vary independently from clients that use it.

Example:

In this example, We have to design a Vehicle. Only Logic that changes is Engine Algorithm. It can Run, Float or Fly.
Depends on vehicle type, logic will get changed. For Car, we will apply "RunningLogic", For Boat, we will apply
"FloatingLogic", etc. Logic will get change according to the Vehicle type.

2.9 TEMPLATE-METHOD PATTERN
----------------------------
The Template Method pattern is a very simple pattern that you will find yourself using frequently. Whenever you
write a parent class where you leave one or more of the methods to be implemented by derived classes, you are
in essence using the Template pattern. The Template pattern formalizes the idea of defining an algorithm in a
class but deffering some of the logic to be implemented in subclasses.

* Define the skeleton of an algorithm in an operation, deferring some steps to subclasses.
* Template Method lets subclasses redefine certain steps of an algorithm without letting them to change the algorithm's structure.

Example:

In this example, "EncryptionAlgorithm" class will give a method "EncryptText()" to encrypt text message but not tells anything
about encryption. "EncryptionAlgorithm" is extended to "TripleDESEncryption" and "RSAEncryption" to apply Triple-DES and RSA 
encryption technique respectively. Here, base class declares but derived classes defined the method logic.

2.10 VISITOR PATTERN
---------------------
Collections are data types widely used in object oriented programming. Often collections contain objects of different 
types and in those cases some operations have to be performed on all the collection elements without knowing the type.

* Represents an operation to be performed on the elements of an object structure.
* Visitor lets you define a new operation without changing the classes of the elements on which it operates.

Example:

In this example, There is "Employee", "Address" and "Contact" class. We want to write values of the property to either Text or XML format.
"IVisitor" is an interface extended to "TextVisitor" and "XmlVisitor" to write in Text and XML format.

3.1 ABSTRACT-FACTORY PATTERN
-----------------------------
Programmers all over the world are trying to avoid the idea of adding code to existing classes in order to make them 
support encapsulating more general information. The Abstract Factory design pattern is used. 
Using this pattern a framework is defined, which produces objects that follow a general pattern and at runtime this 
factory is paired with any concrete factory to produce objects that follow the pattern of a certain country.
In other words, the Abstract Factory is a super-factory which creates other factories (Factory of factories).

* Abstract Factory offers the interface for creating a family of related objects, without explicitly specifying their classes

Example:

In this example, "TextControl" and "ButtonControl" is two different hierarchy that has "TextFactory" and "ButtonFactory" as
Factory classes. To Combine these 2 hierarchy to one common Factory. "IControl" interface is created and extended to 
"TextControl" and "ButtonControl". Now, we have one common factory called "ControlFactory" that exposes only "IControl" and 
have access to two factories.
Here, client program will not come to know all concrete classes. It only exposed with "IControl" and "ControlFactory".

3.2 BUILDER PATTERN
--------------------
This pattern allows a client object to construct a complex object by specifying only its type and content, being shielded 
from the details related to the objects representation. This way the construction process can be used to create different 
representations. The logic of this process is isolated form the actual steps used in creating the complex object, 
so the process can be used again to create a different object form the same set of simple objects as the first one.

* Defines an instance for creating an object but letting subclasses decide which class to instantiate
* Refers to the newly created object through a common interface

3.3 FACTORY PATTERN
--------------------
The ultimate idea is not to expose all concrete class to client. Client should only be aware of base class from which all
concrete classes were derived. A Simple Factory pattern is one that returns an instance of one of several possible classes, 
depending on the data provided to it. Usually all of the classes it returns have a common parent class and common methods, 
but each of them performs a task differently and is optimized for different kinds of data.

* creates objects without exposing the instantiation logic to the client.

Example:

In this example, "Hyundai" is an abstract class that extended to several hyundai car models like "Santro", "Verna", "I10", etc.
Client program need not come to know all concrete classes available instead it only knows about "HyundaiCars" enum.
With the enum, client will come to know details of any cars by knowing only teh abstract class. "HyundaiFactory" will take care of
generating objects based on "HyundaiCars" enum input.

3.4 PROTOTYPE PATTERN
----------------------
The Prototype design pattern is the one in question. It allows an object to create customized objects without knowing 
their class or any details of how to create them. Up to this point it sounds a lot like the Factory Method pattern, 
the difference being the fact that for the Factory the palette of prototypical objects never contains more than one object.

The target classes are constructed by cloning one or more prototype classes and then changing or filling in the details 
of the cloned class to behave as desired.

* specifying the kind of objects to create using a prototypical instance
* creating new objects by copying this prototype

Example:

In this example, I have DNA Samples of more than one person. From which, i have to test Mitochondrial DNA Test and Peternity DNA Test.
DNASample object should not get changed while doing one test. So, object will be cloned and sent for testing so that one testing will
not affect result of another testing. Simply, object will not get changed but deep cloned for multipurpose.

3.5 SINGLETON PATTERN
----------------------
The Singleton assures that there is one and only one instance of a class and provides a global point of access to it. 
There are any number of cases in programming where you need to make sure that there can be only one instance of a class.

* Ensure that only one instance of a class is created.
* Provide a global point of access to the object.

Example:

A typical example is Application Configuration which has "Default" as static property that exposes one object that shared across app domain.
"Configuration" class has "Default" static property that exposes single configuration object to entire App-Domain.
