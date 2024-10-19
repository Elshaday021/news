import React from 'react';
import logo from './logo.svg';
import './App.css';
import { ThemeProvider, createTheme } from '@mui/material';
import { green } from '@mui/material/colors';
import { HttpClientContextProvider } from '../contexts/HttpClientContextProvider';
import { MainLayout } from '../components/layouts';
import { SnackbarProvider } from 'notistack';
import { LocalizationProvider } from '@mui/x-date-pickers';


const theme = createTheme({
  palette: {
    primary: {
      main: "#003da5", //"#fd9b28"
    },
    secondary: {
      main: green[500],
    },
  },
  components: {
    MuiTypography: {
      styleOverrides: {
        root: {},
      },
    },
    MuiButton: {
      styleOverrides: {
        root: {
          textTransform: "none",
        },
      },
    },
    MuiAvatar: {
      styleOverrides: {
        root: {
          border: "0.1px solid #d3d3d3",
        },
      },
    },
    MuiTooltip: {
      styleOverrides: {
        tooltip: {},
      },
    },
  },
  typography: {
    button: {
      textTransform: "capitalize",
    },
  },
});


export const App=()=> {
  return (
    <ThemeProvider theme={theme}>
    <SnackbarProvider
      maxSnack={3}
      anchorOrigin={{
        vertical: "top",
        horizontal: "center",
      }}
      preventDuplicate
      autoHideDuration={5000}
    >
      <HttpClientContextProvider>
        
        {/* <ScrollToTop> */}
        {/* <LocalizationProvider dateAdapter={AdapterDayjs}> */}
          <MainLayout />
        {/* </LocalizationProvider> */}
        {/* </ScrollToTop> */}
      </HttpClientContextProvider>
    </SnackbarProvider>
  </ThemeProvider>
  );
}

