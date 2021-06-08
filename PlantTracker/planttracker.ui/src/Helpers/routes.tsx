import React from 'react';
import { Switch, Route } from 'react-router-dom';
import Home from '../Views/Home'
import Discovery from '../Views/Discovery'
import PlantId from '../Views/PlantId'
import Results from '../Views/Results'
import SinglePlant from '../Views/SinglePlant'
import Watering from '../Views/Watering'
import NotFound from '../Views/NotFound';
import {PlantProps} from '../Helpers/Interfaces/PlantInterfaces';
import {SearchProps} from '../Helpers/Interfaces/SearchInterfaces';
import {User} from '../Helpers/Interfaces/UserInterface';


export default function Routes(user: User): JSX.Element {
    return (
        <Switch>
            <Route exact path='/' component={() => <Home/>} />
            <Route exact path='/Discovery' component={() => <Discovery/>} />
            <Route exact path='/PlantId' component={() => <PlantId/>} />
            <Route exact path='/search/:term' component={(props: SearchProps) => <Results{...props} user={user}/>} />
            <Route exact path='/details' component={(props: PlantProps) => <SinglePlant{...props} user={user}/>} />
            <Route exact path='/Watering' component={(props: PlantProps) => <Watering{...props} user={user}/>} />
            <Route exact path='/' component={() => <Home/>} />
            <Route component={NotFound} />
        </Switch>
    )
}