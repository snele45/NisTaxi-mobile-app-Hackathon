import { StyleSheet } from 'react-native';
import { createNativeStackNavigator, createStackNavigator } from '@react-navigation/native-stack';
import QRCode from 'react-native-qrcode-svg';
import QRCodeStyled from 'react-native-qrcode-styled';
import { NavigationContainer } from '@react-navigation/native';

import { AuthProvider } from './context/AuthContext';
import LoginScreen from './screens/LoginScreen';
import { View, ActivityIndicator } from 'react-native';
import AppNav from './navigation/AppNav';


const Stack = createNativeStackNavigator();


export default function App() {

  return (
    <AuthProvider>
      <AppNav/>
    </AuthProvider>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    padding: 0,
    paddingTop: 80,
    alignItems: 'center',
    justifyContent: 'center',
  },
  root: {
    justifyContent: 'center',
    alignItems: 'center',
  },
  svg: {
    marginTop: 20,
    backgroundColor: '#fff',
    borderRadius: 20,
    overflow: 'hidden',
  },
  logoContainer: {
    position: 'absolute',
    width: 88,
    height: 88,
    backgroundColor: '#fff',
    justifyContent: 'center',
    alignItems: 'center',
  },
  logo: {
    width: '90%',
    height: '90%',
    top: -2,
  },
  userIcon:{
    width: 50,
    height: 50,
  },
  nameText:{
    fontSize: 22,
    fontWeight: '700',
    marginTop: 5,
  },
  fuelText:{
    fontSize: 15,
    fontWeight: '400',
    color: '#8F8F8F',
  },
  shareBtn:{
    marginTop: 40,
    alignItems: 'center',
    justifyContent: 'center',
    paddingVertical: 15,
    paddingHorizontal: 32,
    width: '100%',
    borderRadius: 4,
    elevation: 4,
    backgroundColor: '#F5BF24',
  },
  shareBtnText:{
    fontSize: 22,
    fontWeight: '700',
  },
  promotionsView:{
    marginTop: 40,
  },
  promotion:{
    marginTop: 20,
    width: '100%',
    height: 150,
    backgroundColor: '#F5BF24',
    borderRadius: 10,
  }
});
