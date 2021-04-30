// Imports
// Using the abstract class
import AbstractView from "./AbstractView.js";


// Class ###########################################################>
export default class extends AbstractView {

    // Constructor =================================================>
    constructor()
    {
        super(); // The abstract class Constructor "Base constructor"
        this.setTitle("Settings");
    }



      // Get Html ====================================================>
      async getHtml()
      {
          return `
                  <h1>Settings</h1>
                  <p>Here are the Settings !!!!!!!!!!</p>    
          `;
      }
  
}