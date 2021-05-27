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
                    <p> DASHBOARD </p>
                    <p> Prediction Graf</p>
  
                  `;
      }


    // View Script ====================================================>
    async executeViewScript()
    {  
        await TempGraph();
    }
}