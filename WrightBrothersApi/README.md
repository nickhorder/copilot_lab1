# Lab 3 - Wright Brothers API

This lab is designed to guide you through building upon a C# API project. The API is structured to manage a list of planes. The lab is divided into several demos, each focusing on a different aspect of the project.

## Prerequisites
1. The Resource Configuation Lab is completed, see [Labs Prerequisites](https://github.com/XpiritBV/Copilot-Labs/tree/main#labs-prerequisites)

## Estimated time to complete
- 30 min

## Objectives
- To build upon an existing C# REST API project.
- To structure the API such that it manages a list of planes.
- To learn how to use GitHub Copilot + Chat to assist in creating the API project.
- To organize the code by putting each piece into a separate file.

## Exercise 1 - Code Completion
Using Visual Studio Code  you see I have a solution which is called the Wright Brothers API and that's a reference to the pilots or the copilots.

In this API project you have a controller, it's called a plane controller.
- This plane controller has a list of planes from the Wright Brothers.
- It has a GET method to get all the planes.
- It has a GET method to get a single plane.
- It has a POST method to add a plane.

In this model, you have a plane model, which has an ID, a name, a year, a description and a range in kilometers.

Let's see how Copilot can help me with improving this or continuing on this code base. Let's begin by using GitHub Copilot to add extra planes in the List.

### Step 1 - Add extra planes
- Open Visual Studio Code and the folder `Lab-WrightBrothers`.
- Open the `WrightBrothersApi` folder.
- Open the `PlanesController.cs` file located in the `Controllers` folder.

- Place the cursor after the last plane in the list.
    - `private static readonly List<Plane> Planes = new List<Plane>`
- Type a `,` press `enter`.
- Copilot knows you have a list of items and you probably need a new plane called the Wright Flyer 3, which is the third powered aircraft by the Wright Brothers.
- Press the `tab` key to accept the suggestion.
- Type a `,` press `enter`.
- Press the `tab` key to accept the suggestion.

>[!NOTE]
> Copilot is not only context aware, knows you have a list of items and you probably need the next plane built by the Wright Brothers, the Wright Model A, which is the fourth powered aircraft by the Wright Brothers.
>
> Notice the `year` property even has the correct date.

- The result might look like this:

```csharp
    new Plane
    {
        Id = 3,
        Name = "Wright Flyer III",
        Year = 1905,
        Description = "The third powered aircraft by the Wright Brothers.",
        RangeInKm = 39
    },
    new Plane
    {
        Id = 4,
        Name = "Wright Model A",
        Year = 1908,
        Description = "The first Model A was the first production aircraft.",
        RangeInKm = 77
    }
```

- Press the `tab` key to accept the suggestion.
- Press `backspace` to remove the `,`.

So it already gave your a suggestion about what you could do next. This plane model is not yet complete.

### Step 2 - Update the plane model
It would be nice if we have a image URL so we can display an image about the plane. So let's go to the plane model and let's add a new property.

- Open the `Plane.cs` file located in the `Models` folder.

Use GitHub Copilot to complete the `ImageUrl` property.

- Place the cursor after the `public int RangeInKm { get; set; }` property.
- Start typing `Public string ImageUrl`, Copilot makes a suggetion, press tab.

Copilot understands I need an image and I need to set the URL for that.

- Next, let's go back to the plane controller.

Let's go to the plane controller and let's add the URL to the image.
- Go back to the `PlanesController.cs` file.
- Place cursor after `RangeInKm = 12` for the first plane in the list, then type `,` press `enter`.

Copilot knows you added an attribute to the model and it's suggesting to add add this property, the Image URL.

- Copilot makes a suggetion, press `tab` to accept it.

> This is a non existent URL by the way, but to give you a sense of what's possible.

Let's continue adding all the images so it's also really fast in giving me these suggestions.
- On the second plane entry, place cursor after `RangeInKm = 24`, then type a `,` press `enter`, `tab`.
- On the third plane entry, place cursor after `RangeInKm = 39`, then type a `,` press `enter`, `tab`.
- On the fourth plane entry, place cursor after `RangeInKm = 77`, then type a `,` press `enter`, `tab`.

> Wow! That's much faster than I could do it myself. :thumbsup:

<details>
<summary>Click to see the completed code</summary>

```csharp
    private static readonly List<Plane> Planes = new List<Plane>
    {
        new Plane
        {
            Id = 1,
            Name = "Wright Flyer",
            Year = 1903,
            Description = "The first successful heavier-than-air powered aircraft.",
            RangeInKm = 12,
            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/8/8d/Wright_Flyer.jpg"
        },
        new Plane
        {
            Id = 2,
            Name = "Wright Flyer II",
            Year = 1904,
            Description = "A refinement of the original Flyer with better performance.",
            RangeInKm = 24,
            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/9/9d/Wright_Flyer_II.jpg"
        },
        new Plane
        {
            Id = 3,
            Name = "Wright Flyer III",
            Year = 1905,
            Description = "The third powered aircraft by the Wright Brothers.",
            RangeInKm = 39,
            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/8/8c/Wright_Flyer_III.jpg"
        },
        new Plane
        {
            Id = 4,
            Name = "Wright Model A",
            Year = 1908,
            Description = "The first Model A was the first production aircraft.",
            RangeInKm = 77,
            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/8/8d/Wright_Flyer.jpg"
        }
    };
```
</details>

### Step 3 - Adding new methods
Copilot knows all about the controller. You can get planes, you can add planes, but I want to do more., you have a REST API, so you probably want to edit, delete, and count planes.

##### Add a PUT method
- Place cursor after the last method, `ActionResult<Plane> Post(Plane plane)` method.
- Start typing `[HttpPut]`, Copilot makes a suggestion, press `tab`, press `enter`.

> Copilot might return multiple suggestions, click on the one that looks like the following:

- Press `tab` to accept the suggestion.
- The result might look like this:

```csharp
    [HttpPut("{id}")]
    public IActionResult Put(int id, Plane plane)
    {
        if (id != plane.Id)
        {
            return BadRequest();
        }

        var index = Planes.FindIndex(p => p.Id == id);

        if (index == -1)
        {
            return NotFound();
        }

        Planes[index] = plane;

        return NoContent();
    }
```

> Copilot will suggest to insert a PUT to edit an airplane in existing list and you didn't have to write any code to do this.

##### Add a DELETE method
- Next, let's add a delete to the plane controller.
- Place cursor after the `public ActionResult<Plane> Put(Plane plane)` method, just created.
- Start typing `[HttpDelete]`, Copilot makes a suggetion, press `tab`, press `enter`.

> Copilot might return multiple suggestions, click on the one that looks like the following:

- Press `tab` to accept the suggestion.
- The result might look like this:

```csharp
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var index = Planes.FindIndex(p => p.Id == id);

        if (index == -1)
        {
            return NotFound();
        }

        Planes.RemoveAt(index);

        return NoContent();
    }
```

##### Add a GET method to count the planes
-Next, let's add a way to count the planes.
- Place cursor after the `public ActionResult<Plane> Delete(int id)` method, just created.
- Press `enter` to add a new line.
- Type `// Count all the planes`, press `enter`.
- Copilot makes a suggetion `[HttpGet("count")]`, press `tab`, press `enter`, `tab`.

> Copilot used code generation to create a new method to count the planes.

- The result might look like this:

```csharp
    [HttpGet("count")]
    public ActionResult<int> Count()
    {
        Console.WriteLine("GET /planes/count");
        return Planes.Count;
    }
```

### Step 4 - Adding a logger
This is great! Copilot is creating code, but you have a whole code base and this code base is designed in a certain way.  Maybe you have a certain style of doing things and worked on it for a couple of years and you have invented a certain style of doing things.

For example, maybe you might you might have a kind of logging strategy where you where you log it.

Let's say I want to log the plane that I'm getting.
- In the `public ActionResult<Plane> Get(int id)` method, place cursor after the `var plane = Planes.Find(p => p.Id == id);` field, and press `enter`.
- Start typing `_logger`, Copilot makes a suggetion, press `tab`, press `enter`.
- The result might look like this:

```csharp
    _logger.LogInformation($"GET /plane with Id = [{id}]");
```

> Copilot knows you have a logger and you want to log the plane. Copilot will be context aware there is a style in your code base to put the dashes around the variable.

- Type the 3 dashes around the `[{id}]`, `---`,  and press `enter`.
- Result will look like this:

```csharp
    _logger.LogInformation($"Getting plane with id --- {id} ---");
``` 

- Next, let's add logging to another method.
- In the `public ActionResult<Plane> Post(Plane plane)` method, place cursor after the `Planes.Add(plane);` field, and press `enter`.
- Start typing `_logger`, Copilot makes a suggetion, press `tab`, press `enter`.
- The result will look like this:

```csharp
    _logger.LogInformation($"POST /planes with Id = --- [{plane.Id}] ---");
```
>[!Note]
> Copilot knows you have a logger and you want to log the plane. It also knows that there is a style in your code base to put the dashes around the variable.  Copilot is updating the context of my code base, which is really powerful.
>
> This is a simple example for logging, but it can be any coding style you have implemented in your code base. That's Copilot might take into account to have a consistent code base.

## Summary
>[!Note]
> In Exercise 1, you performed the following tasks:
> 
> 1. **Adding a New Plane to the List**: You used GitHub Copilot to add a new plane, the Wright Flyer III, to the existing list of planes in the `PlanesController.cs` file.
> 
> 2. **Completing the Plane Model**: You added an `ImageUrl` property to the `Plane.cs` model using GitHub Copilot.
> 
> 3. **Adding Image URLs to Planes**: You returned to the `PlanesController.cs` file and added image URLs to the existing planes in the list with the help of GitHub Copilot.
> 
> 4. **Adding New Methods**: You used GitHub Copilot to add new `HttpPut` and `HttpDelete` methods to the `PlanesController.cs` file.
> 
> 5. **Adding Logging**: You added logging to the `Get` and `Post` methods in the `PlanesController.cs` file using GitHub Copilot. The logging messages followed a specific style with dashes around the variable.
> 
> Throughout the exercise, you made extensive use of GitHub Copilot's code completion and suggestion features to add new content and enhance existing code.

## Key Takeaways
Copilot exhibits a high level of intelligence in understanding the tasks at hand. The key takeaways from this discussion about using tools like GitHub Copilot for developers include:~~

- **Enhanced Flow and Productivity:** Developers can experience longer periods of uninterrupted coding flow, potentially extending to 2 hours, compared to the usual 40 minutes. This extended flow leads to the creation of better and more code, efficient debugging, and feature implementation.

- **Increased Satisfaction:** The tool's assistance in handling repetitive tasks not only boosts productivity but also enhances the developer's overall happiness and satisfaction with their coding experience.

- **Automated Assistance:** Features like auto-filling image URLs demonstrate the tool's capability to automate mundane tasks, further contributing to a smoother and more enjoyable coding process.


## Exercise 2 - Explaining Code with Copilot
### Demo 2 - Comments to Code (Method Get Planes by Year)

So what if I want to get the airplanes, but I want to only get the airplanes for a specific year, So let's add a comment, a get method for year.

### Step 1 - Add a comment to the code for suggesting a GET method for year
- Open the `PlanesController.cs` file.
- Place the cursor after the `[HttpGet("count")]` method.
- Press `enter` to add a new line.
- Type `// Get method for year` to add a comment, press `enter`.
- The result will look like this, pres the `tab` key.

```csharp
[HttpGet("year/{year}")]
```

- press `enter` to add the method.

> Copilot might return multiple suggestions, click on the one that looks like the following:

- Press `tab` to accept the suggestion.
- The result might look like this:

```csharp
    // get method for year
    [HttpGet("year/{year}")]
    public ActionResult<List<Plane>> GetYear(int year)
    {
        Console.WriteLine($"GET /plane with Year = [{year}]");
        
        var plane = Planes.FindAll(p => p.Year == year);

        _logger.LogInformation($"Found plane: --- {year} ---");

        if (plane == null)
        {
            return NotFound();
        }

        return plane;
    }
```

- Press the `tab` key to accept the suggestion.

> Notice that Copilot is using the `year` variable in the _logger method.

By typing this, copilot understands like I want to have a get method for a year and because it has the method, it can already suggest the code that you need for that.


>[!Note]
> Remember, Copilot takes into account the log information because you are using it in all methods. It also knows that there is a style in your code base to put the dashes around the variable.

### Step 2 - Check if plane already exists by name
If I want to add a new airplane but it's already there in the list, I want to return a bad request.
- In the `public ActionResult<Plane> Post(Plane plane)` method, place the cursor before the `Planes.Add(plane);` line 
- Type `//Return BadRequest if plane already exists` to add a comment, press `enter`, then press the `tab` key to accept the suggestion.

> Copilot might return multiple suggestions, click on the one that looks like the following:

- Press `tab` to accept the suggestion.
- The result might look like this:

```csharp
    //Return BadRequest if plane already exist
    if (Planes.Any(p => p.Id == plane.Id))
    {
        return BadRequest();
    }
```

> Notice, this is using `by ID` if the plane already exists, by we actually want to check by name.
- Let's remove this code and update comments to provide Copilot with better context.
- Type `//Return BadRequest if plane already exists by name` to add a comment, press `enter`.

> Copilot might return multiple suggestions, click on the one that looks like the following:

- Press `tab` to accept the suggestion.
- The result might look like this:
    
    ```csharp
    //Return BadRequest if plane already exist by name
    if (Planes.Any(p => p.Name == plane.Name))
    {
        return BadRequest();
    }
    ```

## Summary
>[!Note]
> In Exercise 2, you performed the following tasks:
>
> - **Adding a Comment for a New Method**: You opened the `PlanesController.cs` file and added a comment `// Get method for year` before the `[HttpGet("{id}")]` method. This comment was used to indicate the purpose of a new method you were about to create.
> 
> - **Creating a New Method**: You created a new method `GetByYear(int year)` that returns a list of planes for a specific year. This method was generated by Copilot based on your comment.
> 
> - **Renaming the Method and Adding a Parameter**: You renamed the method to `GetByYear` and added a `year` parameter to it.
> 
> - **Adding a Comment for Handling Existing Planes**: You added a comment `//Return BadRequest if plane already exists` before the `Planes.Add(plane);` line in the `public ActionResult<Plane> Post(Plane plane)` method. This comment was used to indicate the purpose of a new code block you were about to add.
> 
> - **Adding a Code Block to Handle Existing Planes**: You added a code block that returns a `BadRequest` response if a plane with the same ID already exists in the list.
> 
> - **Updating the Code Block to Check by Name**: You updated the code block to check if a plane with the same name already exists in the list, instead of checking by ID.
> 
> Throughout the exercise, you used comments to guide Copilot in generating the necessary code. You also made use of Copilot's ability to understand the style and patterns in your codebase.

## Exercise 3 - Creating Unit Tests with Copilot
### Step 1 - Start explaining CoPilot Chat window
Copilot Chat is a feature that acts as an assistant, offering responses and guidance within a codebase. It is particularly helpful for users who are new to a codebase, providing answers and insights about the codebase's contents and structure.

- Open up the Copilot Chat window by clicking on the icon.
- Type `hi` and press `enter`.
- The result will look like this:

```csharp
    // Hello! How can I assist you with your software development needs today?
```

>[!Note]
> You can interact with Copilot Chat, an assistant feature, by clicking its icon and initiating a conversation. This is especially useful for someone new to a codebase, as it can provide assistance and answer questions about the codebase's content and structure.

### Step 1 - Explain the entire file
- Click in the `PlanesController.cs` file.
- In the Copilot Chat window, type `Can you explain this file to me?` and press `enter`.

> When you say this file, Copilot understands I mean the selected file I have in my editor so it tells me about the plane and it has a POST and some methods like a put and it gives me some more information. This can be very useful when you have maybe some complex codes you get around on a code base.

### Step 2 - Explain the Selected Code
You can also use the shortcuts that Copilot has built in.
- In the `PlanesController.cs` file, highlight the `Get` method.
- Hightlight the entire `public ActionResult<Plane> Post(Plane plane)` method.
- Right-click and select `Copilot` and then `Explain this`.

> Copilot will take this question about your code and then explains the the method in Copilot Chat window.  There are multiple ways of getting Copilot to do things for you.

### Step 3 - Create Unit Tests in Chat window
Another powerful thing to use Copilot for is this.  As a developer I want to test my code but I don't see any unit test in this project. I can ask Copilot to create unit tests for the selected codes.
- Again, highlight the entire `public ActionResult<Plane> Post(Plane plane)` method.
- In the `Copilot Chat window`, type `Can you create a unit test for this? and press `enter`.

> Copilot will create a unit test for you.  This is a very powerful feature because it can help you to create unit tests for your code.

>[!Note]
> Copilot suggests writing a controller with a post method and includes **assertions** using **XUnit**, but maybe you use Fluent Assertions. Although Copilot isn't fully context-aware (it doesn't automatically use Fluent Assertions despite them being installed), the tool, will become more context-aware over time. You can specify the use of Fluent Assertions, prompting Copilot to rework the unit tests accordingly, demonstrating its adaptability and potential for a wide range of coding tasks.

- In the `Copilot Chat window`, type `I am using Fluent Fluid Assertions` and press Enter.

> Copilot will rework the unit tests and give you a sample with Fluent Assertions. There's an endless amount of possibilities for this as you can imagine.

### Step 4 - Create Unit Tests in Inline window
Another option to use Copilot for creating tests is use the `Inline` feature.

- Again, hightlight the entire `public ActionResult<Plane> Post(Plane plane)` method.
- Right-click and select `Copilot` and then select `Generate Tests`.

> Copilot will create a unit test and create the `PlanesControllerTest.cs` file with your generated unit test for you.  This is a very powerful feature because it can help you to create unit tests for your code much faster.

- Click `Create` to create the unit test file.
- Click `Accept` to accept the unit test.
- Click on the `Controller` folder and open the `PlanesControllerTest.cs` file to view the unit test.

>[!Note]
> Copilot suggests writing a controller with a post method and includes **assertions** using **XUnit**.

### Step 5 - Generate test data with Copilot
- Open the `PlanesControllerTest.cs` file.
- Hightlight the entire `Post_ValidPlane_ReturnsCreatedAtAction()` method.
- In the `Copilot Chat window`, type `Can you generate test data for 5 iterations for this?` and press `enter`.
- Scroll back up and click `Insert at Cursor` to insert the test data driven unit test.

<details>
<summary>Click to see the completed code</summary>

```csharp
    [Theory]
    [Repeat(5)]
    public void Post_ValidPlane_ReturnsCreatedAtAction()
    {
        // Arrange
        var plane = _fixture.Create<Plane>();

        // Act
        var result = _controller.Post(plane);

        // Assert
        var createdAtActionResult = result.Result.Should().BeOfType<CreatedAtActionResult>().Subject;
        createdAtActionResult.ActionName.Should().Be(nameof(PlanesController.Get));
        createdAtActionResult.RouteValues["id"].Should().Be(plane.Id);
        createdAtActionResult.Value.Should().Be(plane);
    }
    
```

</details>

### Step 6 - Debugging with Copilot
Copilot can also help you figure out problems or help with debugging your code. Let's make a mistake in code on purpose.

- In the method `public ActionResult<Plane> Post(Plane plane)` method, change the if to read `p => p.Year == plane.Name`.
- The result will look like this:

```csharp
    //Return BadRequest if plane already exist by name
    if (Planes.Any(p => p.Year == plane.Name))
```

Of course this this is wrong because we want to check by name not by year.

As a developer and you have a bug and you might want help to fix. Select the codes and ask Copilot to fix it.
- Again, hightlight the entire `public ActionResult<Plane> Post(Plane plane)` method.

There are multiple ways of getting Copilot to do things for you.
- **Right-click**
    - Right-click and select `Copilot` and then select `Explain This`.
    - Right-click and select `Copilot` and then select `Fix This`.
- **Keyboard shortcut**
    - Press `Ctrl + Shift + P` and type `Copilot` and then select `Fix This`.
- **Inline**
    - Press `Ctrl + I` and select `Fix This`.
- **Hover over error**
    - Hover over the red squiggly line and select `Quick Fix`, `Fix using Copilot`.

### Step 7 - Generate Documentation
Developers often find writing documentation tedious because it involves explaining technical details in a clear and concise manner, which can be time-consuming and less engaging compared to the more creative and problem-solving aspects of coding.

Copilot can help you generate documentation for your code.

There are multiple ways of getting Copilot to do things for you.
- **Right-click**
    - Hightlight the entire `public ActionResult<Plane> Post(Plane plane)` method.
    - Right-click and select `Copilot` and then select `Generate Docs`.

> Copilot will put XML on the top of a single method.

- **Inline**
    - Click anywhere in the `PlanesController.cs` file.
    - Press `Ctrl + I` and type `Document all my code` press `enter`.

> Copilot will put XML on the top of every method.

- **Copilot Chat**
    - Click anywhere in the `PlanesController.cs` file.
    - Click Ctrl + A to select all the code in the file.
    - In the `Copilot Chat window`, type `Generate documentation for all my code` and press `enter`.
    - Scroll back up and click `Insert at Cursor` to insert all the code with documentation.

> Copilot will put XML everywhere in the file.

Now you're ready to check in your code and issue a pull request.

### Summary
>[!Note]
> > In Exercise 3, you performed the following tasks:
> 
> - **Exploring Copilot Chat Window**: You learned how to interact with the Copilot Chat window, which acts as an assistant providing responses and guidance within a codebase.
> 
> - **Explaining Selected Code**: You used Copilot's built-in shortcuts to explain the selected code in the `PlanesController.cs` file.
> 
> - **Creating Unit Tests in Chat Window**: You asked Copilot to create unit tests for the selected code in the `PlanesController.cs` file.
> 
> - **Adapting to Fluent Assertions**: You informed Copilot that you're using Fluent Assertions, prompting it to rework the unit tests accordingly.
> 
> - **Creating Unit Tests in Inline**: You used Copilot's Inline feature to generate unit tests for the selected code along with test data.
> 
> - **Debugging with Copilot**: You intentionally introduced an error in your code and used Copilot to help fix it.
> 
> - **Generating Documentation**: You used Copilot to generate documentation for your code in the `PlanesController.cs` file.
> 
> Throughout the exercise, you interacted with Copilot through various methods such as right-clicking, using keyboard shortcuts, and inline commands.

## Exercise 4 - Wright Brothers Flight Simulation
In this exercise, you will be tasked with creating a simulation for the Wright Brothers' first flight. This system will include various elements such as the aircraft, weather conditions, and flight path. You will start by setting up a new project in the `WrightBrothersApi` directory. Following this, you will proceed to define a class that encapsulates the behavior and properties of one or more elements in the simulation. This exercise will test your understanding of object-oriented programming concepts, and give you practical experience in designing and implementing a complex system.

### Steps

### Step 1 - Update API Project
Navigate to the `WrightBrothersApi` directory in the `Lab3-WrightBrothers` folder.
- TBD

### Step 2 - Create Models
In the `Models` directory, create classes to represent the various elements of the flight simulation, such as the Aircraft, Weather conditions, and Flight path.
- TBD

### Step 3 - Create Controller**
In the `Controllers` directory, create a new controller named `FlightSimulationController.cs`. This controller will handle the logic for the flight simulation.
- TBD

### Step 4 - Implement Simulation Logic
In the `FlightSimulationController`, implement the logic for the flight simulation. This could include methods for starting the simulation, updating the flight path based on weather conditions, and landing the aircraft.
-TBD

### Step 5 - Test Your Simulation
Write unit tests for your simulation logic. You can use the skills you learned in Exercise 3 to write these tests. Make sure to test all possible scenarios and edge cases.
- TBD

### Step 6 - Run Your Simulation
Start your simulation by running the `WrightBrothersApi` project. You can do this by using the `dotnet run` command in the terminal.
    ```sh
    dotnet run
    ```
- TBD

### Step 7 - Review and Refactor
Review your code for any possible improvements. Refactor where necessary and ensure your code is clean and well-documented.
- TBD

## Tips
- Remember to commit your changes frequently and push your code to your repository.
- Use the skills and concepts you've learned in the previous exercises.
- Don't hesitate to look up information online or ask for help if you're stuck.

Now you're ready to check in your code and issue a pull request.

## Exercise 5 - Creating a Pull Request with Copilot

### Step 1 - Review Your Changes
Before creating a pull request, review your changes to ensure everything is as expected. 
- TBD

### Step 2 - Stage Your Changes
Stage your changes by adding them to the staging area with the `git add .` command.
- TBD

### Step 3 - Commit Your Changes
Commit your changes with a meaningful commit message using the `git commit -m "Your message"` command.
- TBD

### Step 4 - Push Your Changes
Push your changes to the remote repository using the `git push` command.
- TBD

### Step 5 - Create a Pull Request
Navigate to your GitHub repository in your web browser. Click on the 'Pull requests' tab and then click on 'New pull request'. Choose the branch you want to merge into the base branch and create the pull request.
- TBD

### Step 6 - Review and Merge the Pull Request
Review the changes in the pull request. If everything is as expected, merge the pull request.

- TBD
> Remember to use GitHub Copilot as a tool to assist you in this process. It can provide suggestions for commit messages, code reviews, and more.

### Summary
In this exercise, you learned how to create a pull request using git commands and GitHub. You also used GitHub Copilot to assist in the process.

### References
- This example is based on the awesome work of Thijs Limmen, Xebia Netherlands, [GitHub](ThijSlim)