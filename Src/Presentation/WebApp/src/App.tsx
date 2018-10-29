import * as React from 'react';
import { connect } from 'react-redux';
import './App.css';
import logo from './logo.svg';
import { ISellsState, ISellsStore, SellActions } from './Modules/Sells/Redux';
import SellComponent from './SellComponent';

export type AppProps = ISellsStore & typeof SellActions;

class App extends React.Component<AppProps> {
  public componentDidMount() {
    this.props.loadSells();
  }

  public render() {
    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1 className="App-title">TechTest</h1>
        </header>
        <p className="App-intro">
          Ventas:
        </p>
        {
          this.props.sells.map(s => (
            <SellComponent sell={s}/>
          ))
        }
        
      </div>
    );
  }
}

export default connect(
  ({ sells }: ISellsState) => sells,
  SellActions
)(App);
