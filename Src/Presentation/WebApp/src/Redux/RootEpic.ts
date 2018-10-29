import { combineEpics } from 'redux-observable';
import SellsEpics from '../Modules/Sells/Redux/Epics';

const RootEpic = combineEpics(...[
  ...SellsEpics,
]);

export default RootEpic;