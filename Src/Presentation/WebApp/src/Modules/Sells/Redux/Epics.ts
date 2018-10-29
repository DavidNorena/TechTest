import { Epic, ofType } from 'redux-observable';
import { EMPTY } from 'rxjs';
import { ajax } from "rxjs/ajax";
import { map, mergeMap } from 'rxjs/operators';
import * as A from './Actions';
const { SellActions } = A;

const loadSells: Epic = (action$) =>
  action$.pipe(
    ofType<A.ILoadSells>(A.LOADSELLS),
    mergeMap(() =>
      ajax.getJSON(`http://localhost:50000/api/Orders`).pipe(
        map(response => SellActions.setSells(response))
      )
    )
  );

const setSells: Epic = (action$) =>
  action$.pipe(
    ofType<A.ISetSells>(A.SETSELLS),
    mergeMap(() => EMPTY)
  );

const sellsEpics = [
  loadSells,
  setSells
];

export default sellsEpics;