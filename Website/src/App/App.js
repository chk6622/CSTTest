import React from 'react';
import MyContext from './MyContext';
import ShowArea from './ShowArea';
import './App.css';


export default function App() {
  return (
    <div className="App">
      <header className="App-header">
        <MyContext>
          <ShowArea />
        </MyContext>
      </header>
    </div>
  );
}

