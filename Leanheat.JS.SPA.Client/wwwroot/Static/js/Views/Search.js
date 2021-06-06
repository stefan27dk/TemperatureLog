// Imports
// Using the abstract class
import AbstractView from "./AbstractView.js";
import { GetFormatedDate } from '/static/js/resources/default_scripts.js';
import { Get } from "/static/js/api/crud/get.js";






// Class ###########################################################>
export default class extends AbstractView {

    // Constructor =================================================>
    constructor()
    {
        super(); // The abstract class Constructor "Base constructor"
        this.setTitle("Search");
    }



      // Get Html ====================================================>
      async getHtml()
      {
          return `
               <h1 class="subTitleView">Search by Date</h1>

              <div class="searchContainer">
                    <form>
                      <input id="datePicker" type="date"  name="date">
                     </form>
                    
                     <div id="searchResultContainer" class="searchResultContainer"></div>

               </div>
          `;
      }


    // View Script ====================================================>
    async executeViewScript()
    {
        document.getElementById('viewTitle').innerText = 'Search'; // Change Tittle


        

        // Events ------------------------------------------------------->
        document.getElementById('datePicker').onchange = async function ()
        {
            let searchResultContainer = document.getElementById('searchResultContainer'); // Result Holder
            let searchResponse = await Get(searchAPI, "/Search/GetSearchResult?searchParam=" + GetFormatedDate('datePicker')); // Search Responce

            // Extract Content
            let searchResult = await searchResponse.json().then(content =>
            {
                return content;
            });

      
            let txt = "";

            // Extract data from Content Object
            let size = searchResult.length;
            for (var i = 0; i < size; i++)
            {
                txt += "<br>" + "DateTime:" + "&nbsp&nbsp&nbsp" + searchResult[i]['datetime'] + "&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp" + "Temperature:" + "&nbsp&nbsp&nbsp" + searchResult[i]['predicted_temp'];
            }


            searchResultContainer.innerHTML = txt;
        };
       
    }

}





 