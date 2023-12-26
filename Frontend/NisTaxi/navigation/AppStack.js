import React from 'react';
import {createNativeStackNavigator} from '@react-navigation/native-stack';

import HomeScreen from '../screens/HomeScreen';
import AccountScreen from '../screens/AccountScreen';
import ReceiptsScreen from '../screens/ReceiptsScreen';

const Stack = createNativeStackNavigator();

const AppStack = () => {
  return (
    <Stack.Navigator>
        <Stack.Screen name="Home" component={HomeScreen} options={{ headerShown: false }}/>
        <Stack.Screen name="Account" component={AccountScreen} />
        <Stack.Screen name="Receipts" component={ReceiptsScreen} />
    </Stack.Navigator>
  );
};

export default AppStack;