import './App.css';
import React,{ useState, useEffect, } from 'react';


  function App() {
  
    const [grid, setGrid]=useState(Array(25).fill(false));
    const [score, setScore]=useState(0);
    const [timeLeft, setTimeLeft]=useState(60);
    const [isPlay, setIsPlay]=useState(false);
    const [popUp, setPopUp]=useState(false);
    const [diff, setDiff]=useState(2000);

    const startGame=()=>{
      setScore(0);
      setTimeLeft(60);
      setIsPlay(true);
      setPopUp(false);
      setGrid(Array(25).fill(false));
    };
  
    const stopGame=()=>{
      setIsPlay(false);
      setPopUp(true);
    };
  
    const handleClick=(index:number)=>{
      if(grid[index]){
          setScore((prev)=>prev+1);
          setGrid(Array(25).fill(false));
        }
      };
      
    const restartGame=()=>{
     setGrid(Array(25).fill(false));
     setScore(0);
     setIsPlay(false);
     setDiff(2000);
     setPopUp(false);
     setTimeLeft(60);
    };
  
    useEffect(()=>{
      if(!isPlay) return;
        
      if(timeLeft<=0){
        stopGame();
        return;
      }
              
      const timer=setInterval(()=>{
        setTimeLeft((prev)=>prev-1);
        },1000);

      return ()=>clearInterval(timer);
    },[timeLeft,isPlay]);

    useEffect(()=>{
      if(!isPlay) return;

      const moleInterval=setInterval(()=>{
        const randomNum=Math.floor(Math.random()*25);
        const newGrid=Array(25).fill(false);
        newGrid[randomNum]=true;
        setGrid(newGrid);
      },diff);

      return()=>clearInterval(moleInterval);
    },[isPlay, diff]);

    return (
      <div className="main-container">
        <h1 className="heading">Welcome to The Game!</h1>
        <h2 className="game-name">Whack-A-Mole</h2>
        <div className="container">
          <div className="lef-container">
            <h3 className="find-me">Find Me 🐭!!!</h3>
            <div className="grid">
              {grid.map((isMole,index)=>(
                <div key={index} className={`cell ${isMole ? "mole" : ""}`} onClick={()=>handleClick(index)}></div>
              ))}
            </div>
          </div>
          <div className="rt-container">
            <div className="rt-container-top">
              <h3 className="diff-heading">Choose a difficulty level!</h3>
              <button onClick={()=>setDiff(2000)} disabled={isPlay}>Easy (2s)</button>
              <button onClick={()=>setDiff(1000)} disabled={isPlay}>Medium (1s)</button>
              <button onClick={()=>setDiff(500)} disabled={isPlay}>Hard (0.5s)</button>
            </div>
            <div className="rt-container-dwn">
              <p>Score : {score}</p>
              <p>Time Left : {timeLeft} sec</p>
              <button onClick={startGame} disabled={isPlay} className="st-btn">Start Game</button>
            </div>
          </div>
          {popUp && (
            <div className="popup">
              <div className="popup-content">
                <h2>Game Over</h2>
                <p>Your Score : {score}</p>
                <button onClick={restartGame} className="restart-btn">Restart Game</button>
              </div>
            </div>
          )}
        </div>
      </div>
    );
  };

export default App;
