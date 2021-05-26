// Imports
// Using the abstract class
import AbstractView from "./AbstractView.js";
import { GetTemperatureData } from "/static/js/api/crud/get.js"; 

// Class ###########################################################>
export default class extends AbstractView {

    // Constructor =================================================>
    constructor()
    {
        super(); // The abstract class Constructor "Base constructor"
        this.setTitle("Dashboard");
    }



      // Get Html ====================================================>
      async getHtml()
      {
          return `
                    <p> DASHBOARD </p>
                    <p> Prediction Graf</p>
  
                  `;
      }


    // View Script ====================================================>
    async executeViewScript()
    {  
        //// Get the Temp Data in Array 
        //let resPrommise = await GetTemperatureData(); // Get Responce
        //const tempArr = new Array(10); // Create Temp Array

        //// Extract the Data From the Responce - Prommise - and add it to array
        //await resPrommise.json().then(content => // Get the Temp list
        //{
        //    const contentSize = content.length;
        //    for (var i = 0; i < contentSize; i++)  // Insert Objects to Array (Objects contain - "id" and "predicted_data")
        //    {
        //        tempArr[i] = content[i];
        //    } 
        //});



        // TEMP - DATA !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        let tempArr = [{ "date": "25-05-2021", "time": "17:00", "temp": "22.04" }, { "date": "25-05-2021", "time": "18:00", "temp": "21.07" },
        { "date": "25-05-2021", "time": "19:00", "temp": "19.02" }, { "date": "25-05-2021", "time": "20:00", "temp": "23.09" },
        { "date": "25-05-2021", "time": "21:00", "temp": "16.47" }, { "date": "25-05-2021", "time": "22:00", "temp": "21.72" },
        { "date": "25-05-2021", "time": "23:00", "temp": "18.51" }, { "date": "25-05-2021", "time": "24:00", "temp": "24.05" },
        { "date": "25-05-2021", "time": "1:00", "temp": "27.74" }, { "date": "25-05-2021", "time": "2:00", "temp": "30.06" }];



        // Generate Graph-------------------------------------------------
        let graph = document.createElement("div");  // Create DIV - Graph container holder
        graph.id = 'graph'; // Give it ID
        graph.className = "graphContainer"; // Add Class to the graph container


        let documentFragment = document.createDocumentFragment();  // Create document fragment - Used to store all the graph data - units and append them at once to the graph container to achive better performance

        // Adjustable - Factors
        let heightFactor = 10; //Used - heightFactor * height
        let unitWidth = 70; // In Pixels





        let currentUnitData = document.createElement("div"); // Create the data-unit element once
        currentUnitData.classList.add("graphData"); // Add Class

        const arrSize = tempArr.length; // Arr length - for better performance
        for (var t = 0; t < arrSize; t++)
        {
            let currentTemp = tempArr[t]['temp'];
            let currentUnitHeight = currentTemp * heightFactor; // Generate the height of the data-unit


            let cloneCurrentUnitData = currentUnitData.cloneNode(true); // Colone the div template 
            cloneCurrentUnitData.id = `tempData${t}`; // Give it ID
            cloneCurrentUnitData.style = `width:${unitWidth}px; height:${currentUnitHeight}px`; // Graph - Data - Unit Size
            cloneCurrentUnitData.innerHTML = `<span class="graphDataTemp">${currentTemp} C</span> <span class="graphDataTime">${tempArr[t]['time']}</span>`; // Add TEMP to the graph - Text  // Add time to graph
            documentFragment.appendChild(cloneCurrentUnitData); // Add to Fragment - Store it in the fragment
        }
         
        graph.appendChild(documentFragment); // Add all Data - Units to the Graph
        document.getElementById("app").appendChild(graph); // Add the graph to the Dashboard


    }
}