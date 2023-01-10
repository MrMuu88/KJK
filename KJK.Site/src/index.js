
import React, { useState } from "react";
import { render } from "react-dom";
import {BrowserRouter as Router,Route,Routes} from "react-router-dom";
import Header from "./Components/Header/Header";
import Menu from "./Components/Menu";
import HomePage from "./Pages/HomePage";
import CharacterPage from "./Pages/CharacterPage";
import SpellsPage from "./Pages/SpelllsPage";
import InventoryPage from "./Pages/InventoryPage";

render(<App/>,document.getElementById("root"));


function App(){
  const [isMenuOpen,setMenuOpen] = useState(false);
  return (
  <div>
    <Header openMenu={()=>setMenuOpen(true)}/>
    <Menu isMenuOpen={isMenuOpen} onClose={()=>setMenuOpen(false)}/>
    <Router>
      <Routes>
        <Route path="/" exact element={<HomePage/>}/>
        <Route path="/character" element={<CharacterPage/>}/>
        <Route path="/inventory" element={<InventoryPage/>}/>
        <Route path="/Spells" element={<SpellsPage/>}/>
      </Routes>
    </Router>
  </div>
  );
}