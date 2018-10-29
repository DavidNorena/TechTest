import { applyMiddleware, createStore } from 'redux';
import { createEpicMiddleware } from 'redux-observable';
import { BehaviorSubject } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import RootEpic from './RootEpic';
import RootReducer from './RootReducer';

const configureStore = () => {

  const epicMiddleware = createEpicMiddleware();

  const store = createStore(
    RootReducer,
    applyMiddleware(epicMiddleware)
  );

  const epic$ = new BehaviorSubject(RootEpic);
  // @ts-ignore
  const hotReloadingEpic = (...args) =>
    epic$.pipe(
      // @ts-ignore
      switchMap(epic => epic(...args))
    );
  // @ts-ignore
  epicMiddleware.run(hotReloadingEpic);

  // @ts-ignore
  if (module.hot) {
    // @ts-ignore
    module.hot.accept(() => {
      const newReducer = require('./RootReducer').default;
      store.replaceReducer(newReducer);

      const nextEpic = require('./RootEpic').default;
      epic$.next(nextEpic);
    });
  }

  return store;
};

export default configureStore;