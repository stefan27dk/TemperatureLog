// Imports
// Using the abstract class
import AbstractView from "./AbstractView.js";


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
                            <iframe style="width: 100%; height: 100%;" src="https://iconarchive.com/"></iframe>
  
                  `;
      }
  
}