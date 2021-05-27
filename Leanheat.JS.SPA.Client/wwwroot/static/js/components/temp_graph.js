import { GetTemperatureData } from "/static/js/api/crud/get.js";



export async function TempGraph()
{
    // # Get the Temp Data in Array #
    let resPrommise = await GetTemperatureData(); // Get Responce
    const tempArr = new Array(10); // Create Temperature Array

    // Extract the Data From the Responce - Prommise - and add it to array
    await resPrommise.json().then(content => // Get the Temp list
    {
        for (var i = 0; i < 10; i++)  // Insert Objects to Array (Objects contain - "id" and "predicted_data")
        {
            tempArr[i] = content[i];
        }
    });



    //// TEMP - DATA !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    //let tempArr = [{ "date": "25-05-2021", "time": "17:00", "temp": "22.04" }, { "date": "25-05-2021", "time": "18:00", "temp": "21.07" },
    //{ "date": "25-05-2021", "time": "19:00", "temp": "19.02" }, { "date": "25-05-2021", "time": "20:00", "temp": "23.09" },
    //{ "date": "25-05-2021", "time": "21:00", "temp": "16.47" }, { "date": "25-05-2021", "time": "22:00", "temp": "21.72" },
    //{ "date": "25-05-2021", "time": "23:00", "temp": "18.51" }, { "date": "25-05-2021", "time": "24:00", "temp": "24.05" },
    //{ "date": "25-05-2021", "time": "1:00", "temp": "27.74" }, { "date": "25-05-2021", "time": "2:00", "temp": "30.06" }];



    // Generate Graph -----------------------------------------------------------------------------------------------------------------------------
    let graph = document.createElement("div");  // Create DIV - Graph container holder
    graph.id = 'graph'; // Give it ID
    graph.className = "graphContainer"; // Add Class to the graph container

    // Declare Fragment
    let documentFragment = document.createDocumentFragment();  // Create document fragment - Used to store all the graph data - units and append them at once to the graph container to achive better performance

    // Adjustable - Factors
    let heightFactor = 10; //Used - heightFactor * height
    let unitWidth = 100; // In Pixels






    // Data Units ----------------------------------------------------------------------------------------------------------------------------------
    let currentUnitData = document.createElement("div"); // Create the data-unit element once
    currentUnitData.classList.add("graphData"); // Add Class

    const arrSize = tempArr.length; // Arr length - for better performance
    for (var t = 0; t < arrSize; t++) {
        let currentTemp = tempArr[t]['predicted_temp'];
        let currentUnitHeight = currentTemp * heightFactor; // Generate the height of the data-unit

        // Work on Elelemnt
        let cloneCurrentUnitData = currentUnitData.cloneNode(true); // Colone the div template 
        cloneCurrentUnitData.id = `tempData${t}`; // Give it ID
        cloneCurrentUnitData.style = `width:${unitWidth}px; height:${currentUnitHeight}px`; // Graph - Data - Unit Size

        // Add Text-Data to the current Data - Unit
        cloneCurrentUnitData.innerHTML = `<span class="graphDataTemp">${currentTemp} C
            </span> <span class="graphDataTime">${tempArr[t]['datetime']}</span>`; // Add TEMP to the graph - Text  // Add time to graph

        // Add to Fragment - Store it in the fragment
        documentFragment.appendChild(cloneCurrentUnitData);
    }







    // Data Info - Div - Max - Min - AVG -----------------------------------------------------------------------------------------------------------
    let dataInfoContainer = document.createElement("div"); // Create container for the data Info
    dataInfoContainer.classList.add("dataInfoContainer"); // Add Class

    const allValues = tempArr.map(function (r) { return r.predicted_temp });

    const max = Math.max.apply(Math, allValues); // MAX -  Using MATH MAX --> Apply is used to extract the data from the array object into variables ---> than use the array together with map "map is like loop" --> than specify in the map function which variable to loop and it returns it
    const min = Math.min.apply(Math, allValues); // MIN


    const avg = (allValues.reduce((a, b) => a + b, 0) / tempArr.length).toFixed(2); // AVG
    const biggestDif = (max - min).toFixed(2); // Biggest Differnece
    const mode = ""; // Typpetal
    const median = Median(allValues); // Middle talet

   // Data Info Container
    dataInfoContainer.innerHTML = `<span class="dataInfo" style="color:rgb(0, 255, 234);">Min: ${min}°C</span> <span class="dataInfo" style="color:rgb(255, 136, 120);">Max: ${max}°C</span>
        <span class="dataInfo">Avg: ${avg}°C</span> <span class="dataInfo" style="color:lime;">Median: ${median}°C</span>  <span class="dataInfo" style="color:rgb(221, 110, 255);">Biggest Difference: ${biggestDif}°C</span>
        <span class="dataInfo">Mode: ${mode}</span>`;

    /*documentFragment.appendChild(dataInfoContainer);*/


    // Append
    // Wrapper Div
    let innerGraphWrapper = document.createElement("div"); // Wrapper
    innerGraphWrapper.classList.add("innerGraphHolder"); // Add Class
    innerGraphWrapper.appendChild(documentFragment);



    graph.appendChild(innerGraphWrapper); // Add all Data - Units to the Graph
    graph.appendChild(dataInfoContainer); // Append Data Info
    document.getElementById("app").appendChild(graph); // Add the graph to the Dashboard

}
















// Get Median of Array -----------------------------------------------------------------------------------------------------------------------------
function Median(values) {
    const valuesLength = values.length; // Array length
    // If 0
    if (valuesLength === 0) {
        return 0;
    }

    // Sort
    let sorted = values.sort();

    // If Even
    if (valuesLength % 2 == 0) // IF Even length
    {
        const theEvenMedianIndex = valuesLength / 2;
        const theOddMedianIndex = theEvenMedianIndex - 1;

        return ((sorted[theEvenMedianIndex] + sorted[theOddMedianIndex]) / 2).toFixed(2);
    }

    // If Odd
    return sorted[valuesLength / 2].toFixed(2);
}