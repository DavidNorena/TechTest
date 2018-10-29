import { combineReducers } from 'redux';
import SellsReducer from '../Modules/Sells/SellsReducer';

const RootReducer = combineReducers({
  ...SellsReducer
});

export default RootReducer;