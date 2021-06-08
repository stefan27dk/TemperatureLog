// Imports
// Using the abstract class
import AbstractView from "./AbstractView.js";
import { TempGraph } from "/static/js/components/temp_graph.js"

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
                    <p class="subTitleView"> Prediction Graph</p>
                  `;
      }


    // View Script ====================================================>
    async executeViewScript()
    {
        document.getElementById('viewTitle').innerText = 'DASHBOARD'; // Change Tittle
        await TempGraph();
    }
}